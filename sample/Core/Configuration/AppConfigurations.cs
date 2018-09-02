/**************************************************************** 
 * 作    者：QKL
 * CLR 版本：4.0.30319.42000
 * 创建时间：2018/09/01 17:17:43
 * 当前版本：1.0.0.0
 * 描述说明： 
 *
*=====================================================================
 * 修改人员：
 * 修改时间：
 * 描    述：
 *
 *****************************************************************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Core.Configuration
{
    public static class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> _configurationCache;

        static AppConfigurations() {
            _configurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfiguration Get(string path, string environmentName = null, bool addUserSecrets = false) {
            var cacheKey = path + "#" + environmentName + "#" + addUserSecrets;
            return _configurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName, addUserSecrets)
            );
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null, bool addUserSecrets = false) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if(!string.IsNullOrWhiteSpace(environmentName)) {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();

            if(addUserSecrets) {
                builder.AddUserSecrets(typeof(AppConfigurations).GetTypeInfo().Assembly);
            }

            return builder.Build();
        }
    }
}

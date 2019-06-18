/**************************************************************** 
 * 作    者：QKL
 * CLR 版本：4.0.30319.42000
 * 创建时间：2018/09/01 19:48:57
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args){
            var builder = new DbContextOptionsBuilder<SampleDbContext>()
                .UseSqlServer(BuidConfiguration().GetConnectionString("Default"));
            return new SampleDbContext(builder.Options);
        }

        /// <summary>
        /// 获取站点根目录下appsettings.json配置
        /// </summary>
        /// <returns></returns>
        private static IConfigurationRoot BuidConfiguration(){
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            return build.Build();
        }
    }
}

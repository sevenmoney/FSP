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
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<SampleDbContext>();
            //var configuration
            //            builder.UseSqlServer("Server=XIEZHIPING\\SQL2008; Database=FspSample;User ID=sa;Password=sa123456;");
            builder.UseSqlServer("Server=XIEZHIPING\\SQL2008; Database=FspSample;User ID=sa;Password=sa123456;");
            return new SampleDbContext(builder.Options);
        }
    }
}

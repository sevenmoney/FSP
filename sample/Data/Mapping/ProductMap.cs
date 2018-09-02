/**************************************************************** 
 * 作    者：QKL
 * CLR 版本：4.0.30319.42000
 * 创建时间：2018/08/31 23:27:55
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
using Core.Entities;
using FSP.Datas.EfCore.Configs.FluentMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ProductMap:FspEntityTypeConfiguration<Product,Guid>
    {
        protected override void PostConfigure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("Product");
            builder.Property(p=>p.ProductName).HasMaxLength(20);
            builder.Property(p => p.DefaultPrice).IsRequired().HasColumnType("decimal(18,3)");
        }
    }
}

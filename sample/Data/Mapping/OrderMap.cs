/**************************************************************** 
 * 作    者：QKL
 * CLR 版本：4.0.30319.42000
 * 创建时间：2018/09/02 10:11:01
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
    public class OrderMap:FspEntityTypeConfiguration<Order,Guid>
    {
        protected override void PostConfigure(EntityTypeBuilder<Order> builder) {
            builder.ToTable("Order");
            builder.HasKey(o=>o.Id);
            builder.HasMany(o=>o.OrderProducts)
                .WithOne(op=>op.Order)
                .HasForeignKey(op=>op.OrdderId);
        }
    }
}

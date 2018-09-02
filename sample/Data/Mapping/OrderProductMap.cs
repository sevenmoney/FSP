/**************************************************************** 
 * 作    者：QKL
 * CLR 版本：4.0.30319.42000
 * 创建时间：2018/09/02 11:56:38
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
    public class OrderProductMap:FspEntityTypeConfiguration<OrderProduct>
    {
        protected override void PostConfigure(EntityTypeBuilder<OrderProduct> builder) {
            builder.ToTable("OrderProduct");
            builder.HasKey(op=>op.Id);
        }
    }
}

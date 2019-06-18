using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using FSP.Datas.EfCore.Configs.FluentMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class RoleMap : FspEntityTypeConfiguration<Role, Guid>
    {
        protected override void PostConfigure(EntityTypeBuilder<Role> builder){
            builder.ToTable("Role");
            builder.HasKey(r=>r.Id);
            builder.Property(r => r.RoleName).HasMaxLength(50);
        }
    }
}

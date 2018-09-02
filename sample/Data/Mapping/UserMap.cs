using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Core.Entities;
using FSP.Datas.EfCore.Configs.FluentMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMap:FspEntityTypeConfiguration<User,Guid>
    {
        protected override void PostConfigure(EntityTypeBuilder<User> builder) {
            builder.ToTable("User");
            builder.HasKey(u=>u.Id);
            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.Property(u => u.UserAddress).HasMaxLength(200);
        }
    }
}

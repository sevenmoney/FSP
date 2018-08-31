using System;
using System.Collections.Generic;
using System.Text;
using FSP.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSP.Datas.EfCore.Configs.FluentMap
{
    public class FspEntityTypeConfiguration<TEntity> :IEntityMappingConfiguration,IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// 钩子函数,可以重写此方法
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder) {

        }

        /// <summary>
        /// 应用于实体配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void ApplyEntityConfiguration(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(this);
        }

        /// <summary>
        /// 实体的配置信息
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TEntity> builder) {
            PostConfigure(builder);
        }
    }
}

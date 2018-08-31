using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FSP.Datas.EfCore.Configs.FluentMap;
using Microsoft.EntityFrameworkCore;

namespace FSP.Datas.EfCore
{
    public class FspContext:DbContext,IDisposable
    {
        public FspContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //查找所有继承FspEntityTypeConfiguration类
            //应用实体的配置信息
            var entityTypeConfigurations =
                Assembly.GetExecutingAssembly().GetTypes().Where(type => (type.BaseType?.IsGenericType??false) && type.BaseType.GetGenericTypeDefinition()==typeof(FspEntityTypeConfiguration<>));
            foreach (var typeConfiguration in entityTypeConfigurations) {
                var configuration = (IEntityMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyEntityConfiguration(modelBuilder);
            }
            //Creat
            base.OnModelCreating(modelBuilder);
        }
    }
}

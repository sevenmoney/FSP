using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FSP.Datas.EfCore;
using FSP.Datas.EfCore.Configs.FluentMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class SampleDbContext:FspContext
    {
        public SampleDbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //查找所有继承FspEntityTypeConfiguration类
            //应用实体的配置信息
            var entityTypeConfigurations =
                Assembly.GetExecutingAssembly().GetTypes().Where(type => (type.BaseType?.IsGenericType ?? false) && 
                                                                         (type.BaseType.GetGenericTypeDefinition() == typeof(FspEntityTypeConfiguration<,>)|| type.BaseType.GetGenericTypeDefinition() == typeof(FspEntityTypeConfiguration<>)));
            foreach(var typeConfiguration in entityTypeConfigurations) {
                var configuration = (IEntityMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyEntityConfiguration(modelBuilder);
            }
            //Creat
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //var builder=new ConfigurationBuilder().
            //optionsBuilder.UseSqlServer("Server=MrQ\\sql2008;Database=FSP;User ID=sa;Password=sa123456;");
        }
    }
}

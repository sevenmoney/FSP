using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FSP.Datas.EfCore.Configs.FluentMap
{
    public interface IEntityMappingConfiguration
    {
        /// <summary>
        /// 添加Entity配置到实体容器
        /// </summary>
        /// <param name="modelBuilder"></param>
        void ApplyEntityConfiguration(ModelBuilder modelBuilder);
    }
}

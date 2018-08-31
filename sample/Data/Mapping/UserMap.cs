using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Core.Entities;
using FSP.Datas.EfCore.Configs.FluentMap;

namespace Data.Mapping
{
    public class UserMap:FspEntityTypeConfiguration<User>
    {
        protected void PostConfigure() { }
    }
}

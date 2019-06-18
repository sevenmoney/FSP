using System;
using FSP.Core.Domain.Entities;

namespace Core.Entities
{
    public class Role:BaseEntity<Guid>{
        public string RoleName { get; set; }
    }
}

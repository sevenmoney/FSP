using System;
using System.Collections.Generic;
using System.Text;
using FSP.Core.Domain.Entities;

namespace Core.Entities
{
    public class User:BaseEntity<Guid>
    {
        public string UserName { get; set; }

        public string UserAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FSP.Core.Domain.Entities
{
    public class BaseEntity: BaseEntity<int>,IEntity {
    }

    public class BaseEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}

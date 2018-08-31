using System;
using System.Collections.Generic;
using System.Text;

namespace FSP.Core.Domain.Entities
{
    public class BaseEntity: BaseEntity<int> {
    }

    public class BaseEntity<TPremaryKey> : IEntity<TPremaryKey>
    {
        public TPremaryKey Id { get; set; }
    }
}

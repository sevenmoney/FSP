using System;
using System.Collections.Generic;
using System.Text;

namespace FSP.Core.Domain.Entities
{
    public interface IEntity:IEntity<int>
    {
    }

    public interface IEntity<TPrimaryKey> {
        TPrimaryKey Id { get; set; }
    }
}

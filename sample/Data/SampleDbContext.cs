using System;
using System.Collections.Generic;
using System.Text;
using FSP.Datas.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SampleDbContext:FspContext
    {
        public SampleDbContext(DbContextOptions options) : base(options) { }
    }
}

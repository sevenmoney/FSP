using Microsoft.EntityFrameworkCore;

namespace FSP.Datas.EfCore.ContextProvider
{
    public class SimpleDbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        public TDbContext DbContext { get; }

        public SimpleDbContextProvider(TDbContext dbContext) {
            DbContext = dbContext;
        }

        public TDbContext GetDbContext() {
            return DbContext;
        }
    }
}
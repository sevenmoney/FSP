using Microsoft.EntityFrameworkCore;

namespace FSP.Datas.EfCore.Repositories
{
    public interface IRepositoryWithDbcontext
    {
        DbContext GetDbContext();
    }
}
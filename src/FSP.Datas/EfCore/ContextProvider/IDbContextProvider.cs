namespace FSP.Datas.EfCore.ContextProvider
{
    public interface IDbContextProvider<out TDbContext>
    {
        TDbContext GetDbContext();

    }
}
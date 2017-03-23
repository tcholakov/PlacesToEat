namespace PlacesToEat.Data.Common.Contracts
{
    using System.Linq;

    public interface IDbUserRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(string id);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}

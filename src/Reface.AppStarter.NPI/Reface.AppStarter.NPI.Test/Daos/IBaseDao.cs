namespace Reface.AppStarter.NPI.Test.Daos
{
    public interface IBaseDao<T>
    {
        void Insert(T entity);
    }
}

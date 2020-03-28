namespace Reface.AppStarter.NPI
{
    public interface IDbConnectionContextProvider
    {
        DbConnectionContext Provide();
    }
}

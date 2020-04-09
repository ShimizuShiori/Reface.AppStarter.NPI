namespace Reface.AppStarter.NPI.Test.Services
{
    public interface IUserService
    {
        void DoSomeThingInTran();

        void DoSomeThingWillThrowAnException();

        void DoSomethingAndAnotherThingWillThrowAnException();
    }
}

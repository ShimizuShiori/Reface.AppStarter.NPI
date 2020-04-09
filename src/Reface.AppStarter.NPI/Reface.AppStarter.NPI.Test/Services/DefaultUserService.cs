using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.Attributes;
using Reface.AppStarter.NPI.Test.Daos;
using System;

namespace Reface.AppStarter.NPI.Test.Services
{
    [Component]
    public class DefaultUserService : IUserService
    {
        private readonly IUserDao userDao;

        public DefaultUserService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        [Transaction]
        public void DoSomethingAndAnotherThingWillThrowAnException()
        {
            var self = (IUserService)this;
            self.DoSomeThingInTran();
            self.DoSomeThingWillThrowAnException();
        }

        [Transaction]
        public void DoSomeThingInTran()
        {
            var user = userDao.SelectById(1);
            userDao.DeleteByState(1);
        }

        [Transaction]
        public void DoSomeThingWillThrowAnException()
        {
            throw new InvalidCastException();
        }

        
    }
}

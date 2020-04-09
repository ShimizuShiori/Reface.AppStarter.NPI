using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.NPI.Test.Services;
using Reface.AppStarter.UnitTests;
using System;

namespace Reface.AppStarter.NPI.Test
{
    [TestClass]
    public class DefaultUserServiceTests : TestClassBase<TestAppModule>
    {
        private IUserService GetUserService()
        {
            return this.ComponentContainer.CreateComponent<IUserService>();
        }

        private IDbConnectionContextProvider GetDbConnectionContextProvider()
        {
            return this.ComponentContainer.CreateComponent<IDbConnectionContextProvider>();
        }

        [TestMethod]
        public void DoSomethingInTran()
        {
            IUserService userService = GetUserService();
            userService.DoSomeThingInTran();
        }

        [TestMethod]
        public void DoSomethingWillThrowAnError()
        {
            IUserService userService = GetUserService();
            Assert.ThrowsException<InvalidCastException>(() => userService.DoSomeThingWillThrowAnException());
        }

        [TestMethod]
        public void DoSomethingAndAnotherThingWillThrowAnException()
        {
            IUserService service = GetUserService();
            Assert.ThrowsException<InvalidCastException>(() => service.DoSomethingAndAnotherThingWillThrowAnException());
        }
    }
}

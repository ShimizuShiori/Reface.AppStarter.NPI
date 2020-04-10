using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.Errors;
using Reface.AppStarter.NPI.Test.Entities;
using Reface.AppStarter.NPI.Test.Services;
using Reface.AppStarter.UnitTests;

namespace Reface.AppStarter.NPI.Test
{
    [TestClass]
    public class DbConnectionContextProviderTests : TestClassBase
    {
        [AutoCreate]
        public IOrderService OrderService { get; set; }

        [TestMethod]
        public void UsingDbConnectionContextProvider()
        {
            this.Start(new TestAppModule());

            this.OrderService.Create(new Order());
        }

        [TestMethod]
        public void UsingDbConnectionContextProvider2()
        {
            this.Start(new TestAppModule2());
            Assert.ThrowsException<MustProvideSingletoneInstanceException>(() =>
            {
                this.OrderService.Create(new Order());
            });
        }
    }
}

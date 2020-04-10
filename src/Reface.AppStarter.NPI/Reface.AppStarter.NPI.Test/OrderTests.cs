using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.NPI.Test.Entities;
using Reface.AppStarter.NPI.Test.Services;
using Reface.AppStarter.UnitTests;
using System;

namespace Reface.AppStarter.NPI.Test
{
    [TestClass]
    public class OrderTests : TestClassBase<TestAppModule>
    {
        private IOrderService GetOrderService()
        {
            return this.ComponentContainer.CreateComponent<IOrderService>();
        }

        [TestMethod]
        public void CreateWithCommit()
        {
            var service = this.GetOrderService();
            service.Create(new Order());
        }

        [TestMethod]
        public void CreateWithRollback()
        {
            var service = this.GetOrderService();
            Assert.ThrowsException<InvalidCastException>(() => service.Create(new Order() { ThrowError = true }));
        }
    }
}

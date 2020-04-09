using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.NPI.Test.Entities;
using Reface.AppStarter.NPI.Test.Services;
using Reface.AppStarter.UnitTests;

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
        public void Create()
        {
            var service = this.GetOrderService();
            service.Create(new Order());
        }
    }
}

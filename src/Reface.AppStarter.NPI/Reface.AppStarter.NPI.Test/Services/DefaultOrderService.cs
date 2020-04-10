using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.Attributes;
using Reface.AppStarter.NPI.Test.Entities;

namespace Reface.AppStarter.NPI.Test.Services
{
    [Component]
    public class DefaultOrderService : IOrderService
    {
        private readonly IUserService userService;

        public DefaultOrderService(IUserService userService)
        {
            this.userService = userService;
        }

        [Transaction]
        public void Create(Order order)
        {
            if (order.ThrowError)
                this.userService.DoSomeThingWillThrowAnException();
            else
                this.userService.DoSomeThingInTran();
        }
    }
}

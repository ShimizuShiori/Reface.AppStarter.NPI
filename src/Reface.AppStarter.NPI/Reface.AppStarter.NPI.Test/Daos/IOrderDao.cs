using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.Test.Entities;
using Reface.NPI;

namespace Reface.AppStarter.NPI.Test.Daos
{
    [NpiDao]
    public interface IOrderDao:INpiDao<Order>
    {
        void Insert(Order order);
    }
    
}

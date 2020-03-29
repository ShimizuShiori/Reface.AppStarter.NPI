using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.Test.Entities;
using Reface.NPI;
using System.Collections.Generic;

namespace Reface.AppStarter.NPI.Test.Daos
{
    [NpiDao]
    public interface IUserDao:INpiDao<User>
    {
        User SelectById(int id);

        IList<User> SelectOrderByName();

        void Insert(User user);
        bool UpdateNameById(string name, int id);
        int DeleteByState(int state);
    }
}

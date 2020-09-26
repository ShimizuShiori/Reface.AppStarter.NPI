using Reface.AppStarter.Attributes;
using Reface.AppStarter.NPI.Test.Entities;
using Reface.NPI;
using System.Collections.Generic;

namespace Reface.AppStarter.NPI.Test.Daos
{
    [NpiDao]
    public interface IUserDao : INpiDao<User>, IBaseDao<User>
    {
        User SelectById(int id);

        IList<User> SelectOrderByName();
        bool UpdateNameById(string name, int id);
        int DeleteByState(int state);

        int CountByState(int state);
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.NPI.Test.Daos;
using Reface.AppStarter.NPI.Test.Entities;
using Reface.AppStarter.UnitTests;
using System.Collections.Generic;

namespace Reface.AppStarter.NPI.Test
{
    [TestClass]
    public class DaoTests : TestClassBase<TestAppModule>
    {
        [TestMethod]
        public void GetDaoNotNull()
        {
            IUserDao userDao = this.ComponentContainer.CreateComponent<IUserDao>();
            Assert.IsNotNull(userDao);
        }

        [TestMethod]
        public void ReturnSingleEntity()
        {
            IUserDao userDao = this.ComponentContainer.CreateComponent<IUserDao>();
            User user = userDao.SelectById(1);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ReturnListEntities()
        {
            IUserDao userDao = this.ComponentContainer.CreateComponent<IUserDao>();
            IList<User> users = userDao.SelectOrderByName();
            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void InsertReturnVoid()
        {
            IUserDao userDao = this.ComponentContainer.CreateComponent<IUserDao>();
            userDao.Insert(new User());
        }

        [TestMethod]
        public void UpdateReturnBoolean()
        {
            IUserDao userDao = this.ComponentContainer.CreateComponent<IUserDao>();
            Assert.IsTrue(userDao.UpdateNameById("fc", 1));
        }

        [TestMethod]
        public void DeleteReturnInt()
        {
            IUserDao userDao = this.ComponentContainer.CreateComponent<IUserDao>();
            int row = userDao.DeleteByState(2);
            Assert.AreEqual(10, row);
        }

        [TestMethod]
        public void TestCount()
        {
            IUserDao userDao = this.ComponentContainer.CreateComponent<IUserDao>();
            int count = userDao.CountByState(1);
            Assert.AreEqual(100, count);
        }
    }
}

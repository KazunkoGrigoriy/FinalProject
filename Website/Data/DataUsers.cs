using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.AppUsers;
using Website.DbDataContext;
using Website.Interfaces;

namespace Website.Data
{
    public class DataUsers : IDataUsers
    {
        private DbDataUsers _contextUsers;

        public DataUsers(DbDataUsers contextUsers)
        {
            _contextUsers = contextUsers;
        }
        public void AddUser(User user)
        {
            _contextUsers.Add(user);
            _contextUsers.SaveChanges();
        }

        public void DelUser(int id)
        {
            _contextUsers.Remove(id);
            _contextUsers.SaveChanges();
        }
    }
}

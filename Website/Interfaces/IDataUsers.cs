using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.AppUsers;

namespace Website.Interfaces
{
    public interface IDataUsers
    {
        void AddUser(User user);
        void DelUser(int id);
    }
}

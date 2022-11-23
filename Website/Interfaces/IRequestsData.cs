using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Interfaces
{
    public interface IRequestsData
    {
        IEnumerable<Request> GetRequests();
        void AddRequest(Request request);
        void DeleteRequest(int id);
        void UpdateRequest(int id);
    }
}

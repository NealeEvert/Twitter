using System.Collections.Generic;
using Twitter.Data.Entities;

namespace Twitter.Data.Interfaces
{
    public interface ITwitterRepository
    {
        IEnumerable<User> GetUsers();
    }
}

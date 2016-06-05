using System.Collections.Generic;
using Twitter.Data.Shared.Entities;

namespace Twitter.Data.Interfaces
{
    public interface ITwitterRepository
    {
        IEnumerable<User> GetUsers();
    }
}

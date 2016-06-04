using System.Collections.Generic;
using Twitter.Data.FlatFile.Entities;

namespace Twitter.Data.FlatFile.Interfaces
{
    public interface ITwitterUserDb
    {
        IEnumerable<UserDto> GetUsers();

        IDictionary<string, List<string>> GetUsersAndFollowers();
    }
}

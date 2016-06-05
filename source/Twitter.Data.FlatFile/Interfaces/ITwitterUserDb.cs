using System.Collections.Generic;
using Twitter.Data.FlatFile.Entities;

namespace Twitter.Data.FlatFile.Interfaces
{
    /// <summary>
    /// Twitter User Database Context
    /// </summary>
    public interface ITwitterUserDb
    {
        /// <summary>
        /// Get a list of all the users
        /// </summary>
        /// <returns>Returns a list of all the users in the database context</returns>
        IEnumerable<UserDto> GetUsers();

        /// <summary>
        /// Get a list of users and their combined followers
        /// </summary>
        /// <returns>KeyValuePair of users with all their followers</returns>
        IDictionary<string, List<string>> GetUsersAndFollowers();
    }
}

using System.Collections.Generic;

namespace Twitter.Data.FlatFile.Entities
{
    /// <summary>
    /// User Data Transfer Object
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of names of users that this user follows
        /// </summary>
        public IEnumerable<string> Follows { get; set; }
    }
}

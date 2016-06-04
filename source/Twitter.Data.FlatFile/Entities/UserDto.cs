using System.Collections.Generic;

namespace Twitter.Data.FlatFile.Entities
{
    public class UserDto
    {
        public string Name { get; set; }

        public IEnumerable<string> Follows { get; set; }
    }
}

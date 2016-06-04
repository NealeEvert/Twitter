using System.Collections.Generic;

namespace Twitter.Data.Entities
{
    public class User
    {
        public string Name { get; set; }

        public IList<User> Follows { get; set; }

        public IList<Tweet> Tweets { get; set; }
    }
}

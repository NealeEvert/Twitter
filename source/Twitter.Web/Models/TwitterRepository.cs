using System.Collections.Generic;
using System.Linq;
using Twitter.Data.SharedEntities.Entities;

namespace Twitter.Web.Models
{
    public class TwitterRepository : ITwitterRepository
    {
        private readonly List<User> _twitterUsers;

        public TwitterRepository(Data.Interfaces.ITwitterRepository twitterRepository)
        {
            _twitterUsers = twitterRepository.GetUsers().ToList();
        }

        public List<User> GetTwitterUsers()
        {
            return _twitterUsers;
        }
    }
}
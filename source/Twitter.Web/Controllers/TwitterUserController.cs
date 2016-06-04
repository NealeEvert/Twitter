
using System.Collections.Generic;
using System.Web.Http;
using Twitter.Core.Config;
using Twitter.Data.Entities;
using Twitter.Web.Models;

namespace Twitter.Web.Controllers
{
    public class TwitterUserController : ApiController
    {
        public ITwitterRepository TwitterUsers { get; set; }
        
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            TwitterUsers = new TwitterRepository(Factory.Resolve<Data.Interfaces.ITwitterRepository>());
            return TwitterUsers.GetTwitterUsers();
        }
    }
}

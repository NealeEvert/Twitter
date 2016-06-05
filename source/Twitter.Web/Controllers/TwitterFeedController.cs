using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Twitter.Core.Config;
using Twitter.Data.Shared.Entities;
using Twitter.Web.Models;

namespace Twitter.Web.Controllers
{
    public class TwitterFeedController : ApiController
    {
        public ITwitterRepository TwitterRepo { get; set; }
        
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            try
            {
                TwitterRepo = new TwitterRepository(Factory.Resolve<Data.Interfaces.ITwitterRepository>());
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex);
            }
            return TwitterRepo.GetTwitterUsers();
        }
    }
}

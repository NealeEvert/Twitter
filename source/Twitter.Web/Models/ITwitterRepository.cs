using System.Collections.Generic;
using Twitter.Data.Entities;

namespace Twitter.Web.Models
{
    public interface ITwitterRepository
    {
        List<User> GetTwitterUsers();
    }
}
using System.Collections.Generic;
using Twitter.Data.Shared.Entities;

namespace Twitter.Web.Models
{
    public interface ITwitterRepository
    {
        List<User> GetTwitterUsers();
    }
}
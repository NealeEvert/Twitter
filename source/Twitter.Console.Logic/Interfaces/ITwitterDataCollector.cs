using System.Collections.Generic;
using Twitter.Data.SharedEntities.Entities;

namespace Twitter.Console.Logic.Interfaces
{
    public interface ITwitterDataCollector
    {
        IList<User> GetTwitterFeed();
    }
}
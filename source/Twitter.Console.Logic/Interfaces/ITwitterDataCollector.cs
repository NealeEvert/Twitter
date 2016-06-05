using System.Collections.Generic;
using Twitter.Data.Shared.Entities;

namespace Twitter.Console.Logic.Interfaces
{
    public interface ITwitterDataCollector
    {
        IList<User> GetTwitterFeed();
    }
}
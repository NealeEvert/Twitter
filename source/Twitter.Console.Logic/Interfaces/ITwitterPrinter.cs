using System.Collections.Generic;

namespace Twitter.Console.Logic.Interfaces
{
    public interface ITwitterPrinter
    {
        IList<string> PrintFeed();
    }
}
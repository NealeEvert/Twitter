using System.Linq;
using Twitter.Console.Logic.Config;
using Twitter.Console.Logic.Interfaces;

namespace Twitter.Console
{
    public class Program
    {
        private static void Main()
        {
            var output = Factory.Resolve<ITwitterPrinter>().PrintFeed().ToList();
            foreach (var o in output)
            {
                System.Console.WriteLine(o);
            }

            System.Console.ReadLine();
        }
    }
}

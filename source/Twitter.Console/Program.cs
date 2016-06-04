using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Twitter.Data.Entities;

namespace Twitter.Console
{
    public class Program
    {
        private static void Main()
        {
            RunAsync().Wait();

            System.Console.ReadLine();
        }

        private static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61312/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/TwitterUser/getall");
                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadAsAsync<IList<User>> ();
                    foreach (var user in users.OrderBy(u => u.Name))
                    {
                        System.Console.WriteLine(user.Name);
                        var allTweets = user.Follows?.SelectMany(f => f.Tweets).Union(user.Tweets);

                        if (allTweets == null) continue;
                        foreach (var tweet in allTweets.OrderBy(t => t.Order))
                        {
                            System.Console.WriteLine($"@{tweet.Name}: {tweet.Message}");
                        }
                    }
                }
            }
        }
    }
}

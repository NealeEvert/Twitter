using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Twitter.Console.Logic.Config;
using Twitter.Console.Logic.Interfaces;
using Twitter.Core;
using Twitter.Data.SharedEntities.Entities;

namespace Twitter.Console.Logic.Implementation
{
    public class TwitterDataCollector : ITwitterDataCollector
    {
        internal static IList<User> Users;

        public IList<User> GetTwitterFeed()
        {
            RunAsync().Wait();
            return Users;
        }

        private static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Factory.Resolve<IConfigurationManager>().GetAppSetting(ConfigurationSettings.TwitterFeedURL));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/TwitterFeed/getall");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Users = new JavaScriptSerializer().Deserialize<List<User>>(data);
                }
            }
        }
    }
}

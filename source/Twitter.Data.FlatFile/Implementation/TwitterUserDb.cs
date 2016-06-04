using System.Collections.Generic;
using System;
using System.Linq;
using Twitter.Core.Config;
using Twitter.Data.FlatFile.Entities;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Data.FlatFile.Implementation
{
    public class TwitterUserDb : ITwitterUserDb
    {
        private const string UserFollowingSeparator = " follows ";
        private const string UserFollowersSeparator = ",";

        private readonly IFileDataReader _fileDataReader;

        public TwitterUserDb()
        {
            _fileDataReader = Factory.Resolve<IFileDataReader>();
        }

        public TwitterUserDb(IFileDataReader fileDataReader)
        {
            _fileDataReader = fileDataReader;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = GetUsersAndFollowers();
            var usersWithoutFollowers = users.SelectMany(us => us.Value).Distinct().Where(f => !users.ContainsKey(f));

            return users.Select(user => new UserDto {Name = user.Key, Follows = user.Value.Distinct()}).Union(
                    usersWithoutFollowers.Select(uwof => new UserDto { Name = uwof })).ToList();
        }

        public IDictionary<string, List<string>> GetUsersAndFollowers()
        {
            var users = new Dictionary<string, List<string>>();

            var lines = _fileDataReader.GetFileData(ConfigurationSettings.UsersDataFilePathKey);
            foreach (var line in lines.Where(l => l.Contains(UserFollowingSeparator)).Select(l => l.Split(new[] { UserFollowingSeparator }, StringSplitOptions.RemoveEmptyEntries)))
            {
                List<string> userFollows;
                var name = line[Field.Name].Trim();
                var follows = line[Field.Follows].Split(new[] { UserFollowersSeparator }, StringSplitOptions.RemoveEmptyEntries).Select(f => f.Trim()).ToArray();
                
                if (!users.TryGetValue(name, out userFollows))
                {
                    userFollows = new List<string>();
                    users.Add(name, userFollows);
                }
                userFollows.AddRange(follows);
            }

            return users;
        }

        internal static class Field
        {
            public static int Name = 0, Follows = 1;
        }
    }
}

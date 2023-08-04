using NotificationSystem.DAL.Entities;
using System.Diagnostics.Metrics;

namespace NotificationSystem.DAL.Data
{
    internal sealed class UserDatabase
    {
        private List<User> Users { get; set; }
        private static UserDatabase instance = null;
        private static int Count = 0;
        public static UserDatabase GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDatabase();
                    Count++;
                    Console.WriteLine(Count);
                }
                return instance;
            }
        }
        private UserDatabase()
        {
            Users = new List<User>();
            Users.AddRange(new List<User>{
                new()
                {
                    Name = "user1",
                    ContactInformation = "user1@gmail.com",
                    ContactType = ContactMode.email,
                    Id = 1,
                },
                new()
                {
                    Name = "user2",
                    ContactInformation = "user2@gmail.com",
                    ContactType = ContactMode.email,
                    Id = 2,
                },
                new()
                {
                    Name = "user3",
                    ContactInformation = "9876543213",
                    ContactType = ContactMode.email,
                    Id = 3,
                },
                new()
                {
                    Name = "user4",
                    ContactInformation = "user4@gmail.com",
                    ContactType = ContactMode.email,
                    Id = 4,
                },
                new()
                {
                    Name = "user5",
                    ContactInformation = "9876543210",
                    ContactType = ContactMode.email,
                    Id = 5,
                },
            });
            Count++;
            Console.WriteLine("Count"+ Count);
        }
        public List<User> GetUsers()
        {
            return Users;
        }
    }
}

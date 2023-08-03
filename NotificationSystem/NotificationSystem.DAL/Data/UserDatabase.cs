using NotificationSystem.DAL.Entities;

namespace NotificationSystem.DAL.Data
{
    internal class UserDatabase
    {
        private List<User> Users { get; set; }
        public UserDatabase()
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
                    ContactType = ContactMode.sms,
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
                    ContactType = ContactMode.sms,
                    Id = 5,
                },
            });
        }
        public List<User> GetUsers()
        {
            return Users;
        }
    }
}

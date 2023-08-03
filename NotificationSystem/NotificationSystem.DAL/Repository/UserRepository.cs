using NotificationSystem.DAL.Data;
using NotificationSystem.DAL.Entities;

namespace NotificationSystem.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDatabase database;

        public UserRepository() { 
            database = new UserDatabase();
        }
        public List<User> GetUsers()
        {
           return database.GetUsers();
        }

    }
}

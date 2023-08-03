using NotificationSystem.DAL.Entities;

namespace NotificationSystem.DAL.Repository
{
    public interface IUserRepository
    {
        List<User> GetUsers();

    }
}

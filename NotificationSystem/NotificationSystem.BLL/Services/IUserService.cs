using NotificationSystem.BLL.Dtos;

namespace NotificationSystem.BLL.Services
{
    internal interface IUserService
    {
        List<UserDto> GetAllUsers();
        List<UserDto> GetUsersByChannel(NotificationType notificationType);
    }
}

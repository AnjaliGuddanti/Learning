using NotificationSystem.BLL.Dtos;

namespace NotificationSystem.BLL.Services
{
    internal interface INotificationChannel
    {
       void SendNotification(NotificationDto notificationDto,UserDto userDto);

    }
}

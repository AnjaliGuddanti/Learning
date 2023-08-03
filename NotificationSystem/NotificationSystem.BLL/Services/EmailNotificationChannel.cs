using NotificationSystem.BLL.Dtos;

namespace NotificationSystem.BLL.Services
{
    internal class EmailNotificationChannel : INotificationChannel
    {
        public void SendNotification(NotificationDto notificationDto,UserDto user)
        {
            Console.WriteLine($"sending message to {user.Name} \n subject: {notificationDto.Subject} \n message :{notificationDto.MessageBody} \n");
        }
    }
}

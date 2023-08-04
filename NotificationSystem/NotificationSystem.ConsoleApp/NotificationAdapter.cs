using NotificationSystem.BLL.Dtos;
using NotificationSystem.BLL.Services;
using NotificationSystem.ConsoleApp.Model;

namespace NotificationSystem.ConsoleApp
{
    public class NotificationAdapter : INotitificationAdapter
    {
       
        private static NotificationDto ConvertNotification(NotificationModel notification)
        {
            NotificationDto notificationDto = new();
            notificationDto.Subject = notification.Subject;
            notificationDto.MessageBody = notification.MessageBody;
            notificationDto.ChannelOfNotification = (BLL.Dtos.NotificationType)notification.ChannelOfNotification;
            return notificationDto;
        }

        void INotitificationAdapter.Notify(NotificationModel notification)
        {
            var notifictionDto = ConvertNotification(notification);
            NotificationFacade notificationFacade = new();
            notificationFacade.SendNotification(notifictionDto);
        }
    }
}

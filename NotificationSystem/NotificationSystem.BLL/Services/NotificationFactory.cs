using NotificationSystem.BLL.Dtos;

namespace NotificationSystem.BLL.Services
{
    internal class NotificationFactory
    {
        public INotificationChannel CreateChannel(NotificationType notificationType)
        {
            if(notificationType ==NotificationType.email)
            {
                return new EmailNotificationChannel();
            }
            else if (notificationType == NotificationType.sms)
            {
                return new SMSNotificationChannel();
            }
            else
            {
                return null;

            }
            
        }
    }
}

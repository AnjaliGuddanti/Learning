using NotificationSystem.BLL.Dtos;

namespace NotificationSystem.BLL.Services
{
    internal class NotificationFactory
    {
        public static INotificationChannel CreateChannel(NotificationType notificationType)
        {
            INotificationChannel? channel = null;
            switch (notificationType)
            {
                case NotificationType.email:
                    channel = new EmailNotificationChannel();
                    break;
                case NotificationType.sms:
                    channel = new SMSNotificationChannel();
                    break;
                default:
                    break;
            }
            return channel;
        }
    }
}

namespace NotificationSystem.BLL.Dtos
{
    public class NotificationDto
    {
        public NotificationType ChannelOfNotification { get; set; }

        public string? Subject { get; set; }
        public string? MessageBody { get; set; }

    }
}

namespace NotificationSystem.ConsoleApp.Model
{
    internal class NotificationModel
    {
       public NotificationType ChannelOfNotification { get; set; }
       public string? Subject { get; set; }
       public string? MessageBody { get; set; }
    }
}

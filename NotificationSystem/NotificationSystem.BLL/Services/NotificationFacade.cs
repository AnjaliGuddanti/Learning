using NotificationSystem.BLL.Dtos;
using NotificationSystem.DAL.Repository;

namespace NotificationSystem.BLL.Services
{
    public class NotificationFacade
    {
        private IUserService UserService { get; set; }
        public NotificationFacade() {
            
            UserService = new UserService();
        }
        public void SendNotification(NotificationDto notificationDto)
        { 
            INotificationChannel notificationChannel =NotificationFactory.CreateChannel(notificationDto.ChannelOfNotification);
            if(notificationChannel != null)
            {
                var users = UserService.GetUsersByChannel(notificationDto.ChannelOfNotification);
                if (users.Count != 0)
                {
                    foreach (var user in users)
                    {
                        notificationChannel.SendNotification(notificationDto, user);
                    }
                }
                else
                {
                    Console.WriteLine($"Users not subscribed to the {notificationDto.ChannelOfNotification}");
                }
                
            }
            else
            {
                Console.WriteLine("Invalid Channel");
            }
        }
    }
}

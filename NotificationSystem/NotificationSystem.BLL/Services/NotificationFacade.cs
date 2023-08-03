using NotificationSystem.BLL.Dtos;
using NotificationSystem.DAL.Repository;

namespace NotificationSystem.BLL.Services
{
    public class NotificationFacade
    {
        private IUserRepository userRepository { get; set; }
        private List<UserDto> users { get; set; }
        private IUserService userService { get; set; }
        public NotificationFacade() {
            userRepository = new UserRepository();
            userService = new UserService();
        }
        public void SendNotification(NotificationDto notificationDto)
        { 
            INotificationChannel notificationChannel =new NotificationFactory().CreateChannel(notificationDto.ChannelOfNotification);
            users = userService.GetUsersByChannel(notificationDto.ChannelOfNotification);
            foreach (var user in users)
            {
                notificationChannel.SendNotification(notificationDto, user);
            }
            
        }
    }
}

using NotificationSystem.BLL.Dtos;
using NotificationSystem.DAL.Repository;

namespace NotificationSystem.BLL.Services
{


    internal class UserService : IUserService
    {
        private IUserRepository userRepository { get; set; }
        public UserService()
        {
             userRepository = new UserRepository();
        }
        public List<UserDto> GetUsersByChannel(NotificationType notificationType)
        {
           return GetAllUsers().Where(user=>user.ContactType== (DAL.Entities.ContactMode)notificationType).ToList();            
        }

        public List<UserDto> GetAllUsers()
        {
            return userRepository.GetUsers().Select(_users=> 
            new UserDto { 
                Name=_users.Name ,
                ContactInformation=_users.ContactInformation,
                ContactType=_users.ContactType
            }).ToList();
            
        }
    }
}

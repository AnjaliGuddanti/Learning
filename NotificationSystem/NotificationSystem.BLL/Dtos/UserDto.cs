using NotificationSystem.DAL.Entities;

namespace NotificationSystem.BLL.Dtos
{
    internal class UserDto
    {
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
        public ContactMode ContactType { get; set; }
    }
}

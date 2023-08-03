namespace NotificationSystem.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
        public ContactMode ContactType { get; set; }
     
    }
}

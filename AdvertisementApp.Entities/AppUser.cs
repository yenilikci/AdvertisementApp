namespace AdvertisementApp.Entities
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<AppUserRole> UserRoles { get; set; }
    }
}
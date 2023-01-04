namespace AdvertisementApp.Entities
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; } // navigation properties
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
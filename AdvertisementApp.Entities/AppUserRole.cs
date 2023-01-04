namespace AdvertisementApp.Entities
{
    public class AppUserRole : BaseEntity
    {
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int RoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
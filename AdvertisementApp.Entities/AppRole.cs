namespace AdvertisementApp.Entities
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
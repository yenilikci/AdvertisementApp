namespace AdvertisementApp.Entities
{
    public class AppRole : BaseEntity
    {
        public string Defination { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
namespace LocalFriendzApi.Domain.Models
{
    public class Contact : Entity
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public AreaCode? AreaCode { get; set; }
    }
}

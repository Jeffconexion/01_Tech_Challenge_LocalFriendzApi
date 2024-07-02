using LocalFriendzApi.Domain.Models;

namespace LocalFriendzApi.Application.Request
{
    public class CreateContactRequest
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CodeRegion { get; set; }

        public Contact ToEntity(CreateContactRequest request)
        {
            return new Contact()
            {

                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                AreaCode = new AreaCode { CodeRegion = request.CodeRegion }
            };
        }
    }
}

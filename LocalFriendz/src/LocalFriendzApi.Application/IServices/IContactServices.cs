using LocalFriendzApi.Application.Request;
using LocalFriendzApi.Application.Response;
using LocalFriendzApi.Domain.Models;

namespace LocalFriendzApi.Application.IServices
{
    public interface IContactServices
    {
        Task<Response<Contact?>> CreateContact(CreateContactRequest request);
        Task<PagedResponse<List<Contact>?>> GetAllContactsWithAreaCode(GetAllContactRequest request);
        Task<Response<Contact?>> UpdateContact(Guid id, UpdateContactRequest request);
        Task<Response<Contact?>> DeleteContact(Guid id);
        Task<PagedResponse<List<Contact>?>> GetByFilter(string codeRegion);
    }
}

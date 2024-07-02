using LocalFriendzApi.Application.IServices;
using LocalFriendzApi.Application.Request;
using LocalFriendzApi.Application.Response;
using LocalFriendzApi.Domain.IRepositories;
using LocalFriendzApi.Domain.Models;

namespace LocalFriendzApi.Application.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository _contactRepository;


        public ContactServices(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Response<Contact?>> CreateContact(CreateContactRequest request)
        {

            var contact = request.ToEntity(request);

            try
            {
                await _contactRepository.Add(contact);
                return new Response<Contact?>(contact, 201, message: "Contact created with sucess!");
            }
            catch (Exception ex)
            {
                return new Response<Contact?>(contact, 400, message: ex.Message);
            }
        }

        public async Task<Response<Contact?>> DeleteContact(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Contact>?>> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Contact>?>> GetByFilter(string codeRegion)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Contact?>> UpdateContact(Guid id, UpdateContactRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

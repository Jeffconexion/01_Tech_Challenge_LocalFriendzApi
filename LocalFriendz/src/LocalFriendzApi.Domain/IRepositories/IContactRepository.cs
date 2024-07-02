using LocalFriendzApi.Domain.Models;

namespace LocalFriendzApi.Domain.IRepositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetContactByCodeRegion();
        Task<ExternalAreaCode> GetExternalAreaCode();
    }
}

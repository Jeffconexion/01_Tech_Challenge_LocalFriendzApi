using LocalFriendzApi.Domain.IRepositories;
using LocalFriendzApi.Domain.Models;
using LocalFriendzApi.Infrastructure.Data.Context;
using LocalFriendzApi.Infrastructure.ExternalServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocalFriendzApi.Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly IAreaCodeExternalService _areaCodeExternalService;
        public ContactRepository(AppDbContext context, IAreaCodeExternalService areaCodeExternalService) : base(context) { _areaCodeExternalService = areaCodeExternalService; }

        public async Task<IEnumerable<Contact>> GetContactByCodeRegion()
        {
            return Db.Contacts.AsNoTracking()
                     .Where(c => c.AreaCode.CodeRegion.Equals("79"))
                     .Include(c => c.AreaCode);
        }

        public async Task<ExternalAreaCode> GetExternalAreaCode()
        {
            var result = await _areaCodeExternalService.GetAreaCode(21);
            return result;
        }
    }
}

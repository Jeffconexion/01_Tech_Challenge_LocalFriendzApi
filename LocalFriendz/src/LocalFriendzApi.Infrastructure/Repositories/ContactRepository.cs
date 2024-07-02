using LocalFriendzApi.Domain.IRepositories;
using LocalFriendzApi.Domain.Models;
using LocalFriendzApi.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocalFriendzApi.Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {

        public ContactRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Contact>> GetContactByCodeRegion(string codeRegion)
        {
            return Db.Contacts.AsNoTracking()
                     .Where(c => c.AreaCode.CodeRegion.Equals(codeRegion))
                     .Include(c => c.AreaCode);
        }

        public async Task<IEnumerable<Contact>> GetAllContactWithAreaCode()
        {
            return Db.Contacts.AsNoTracking()
                     .Include(c => c.AreaCode);
        }
    }
}

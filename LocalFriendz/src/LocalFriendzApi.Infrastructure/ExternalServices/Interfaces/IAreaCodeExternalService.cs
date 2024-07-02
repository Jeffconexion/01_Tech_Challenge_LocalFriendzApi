using LocalFriendzApi.Domain.Models;
using Refit;

namespace LocalFriendzApi.Infrastructure.ExternalServices.Interfaces
{
    public interface IAreaCodeExternalService
    {
        [Get("/ddd/v1/{areaCode}")]
        Task<ExternalAreaCode> GetAreaCode(int areaCode);
    }
}

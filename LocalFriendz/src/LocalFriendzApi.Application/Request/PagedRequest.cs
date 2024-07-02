using LocalFriendzApi.Application.Response;

namespace LocalFriendzApi.Application.Request
{
    public abstract class PagedRequest
    {
        public int PageSize { get; set; } = ConfigurationPage.DefaultPageSize;
        public int PageNumber { get; set; } = ConfigurationPage.DefaultPageNumber;
    }
}

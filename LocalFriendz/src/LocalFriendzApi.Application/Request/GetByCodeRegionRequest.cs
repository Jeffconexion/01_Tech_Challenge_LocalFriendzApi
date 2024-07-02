namespace LocalFriendzApi.Application.Request
{
    public class GetByCodeRegionRequest : PagedRequest
    {
        public string CodeRegion { get; set; }

        public static GetByCodeRegionRequest RequestMapper(string codeRegion)
        {
            return new GetByCodeRegionRequest() { CodeRegion = codeRegion };
        }
    }
}

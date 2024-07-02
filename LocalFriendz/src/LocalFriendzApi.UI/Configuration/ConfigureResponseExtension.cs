using LocalFriendzApi.Application.Response;
using LocalFriendzApi.Domain.Models;

namespace LocalFriendzApi.UI.Configuration
{
    public static class ConfigureResponseExtension
    {
        public static IResult ConfigureResponseStatus(this PagedResponse<List<Contact>?> response)
        {
            switch (response.Code)
            {
                case 200:
                    return TypedResults.Ok(response);
                case 201:
                    return TypedResults.Created(response.Data.FirstOrDefault().Name);
                    break;
                case 400:
                    return TypedResults.BadRequest(response);
                    break;
                case 404:
                    return TypedResults.NotFound(response);
                    break;
                default:
                    return TypedResults.NoContent();
            }
        }

        public static IResult ConfigureResponseStatus(this Response<Contact>? response)
        {
            switch (response.Code)
            {
                case 200:
                    return TypedResults.Ok(response);
                case 201:
                    return TypedResults.Created(response.Data.Name);
                    break;
                case 400:
                    return TypedResults.BadRequest(response);
                    break;
                case 404:
                    return TypedResults.NotFound(response);
                    break;
                default:
                    return TypedResults.NoContent();
            }
        }
    }
}

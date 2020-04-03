using Soccer.Common.Models;
using System.Threading.Tasks;
using TravelBills.Common.Models;

namespace Soccer.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);

        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);

        Task<Response> RegisterUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest);

        Task<Response> RecoverPasswordAsync(string urlBase, string servicePrefix, string controller, EmailRequest emailRequest);

        Task<Response> GetUserByEmail(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, EmailRequest request);


    }
}

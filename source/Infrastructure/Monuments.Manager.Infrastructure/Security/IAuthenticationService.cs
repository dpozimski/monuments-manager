using System.Threading.Tasks;

namespace Monuments.Manager.Infrastructure.Security
{
    public interface IAuthenticationService
    {
        Task<UserToken> AuthenticateAsync(string username, string password);
    }
}

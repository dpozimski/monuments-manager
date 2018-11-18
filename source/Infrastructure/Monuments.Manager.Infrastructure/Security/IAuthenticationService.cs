using System.Threading.Tasks;

namespace Monuments.Manager.Infrastructure.Security
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}

using Empresas.Domain.Entities.OAuth;
using Empresas.Domain.Interfaces;

namespace Empresas.Domain;

public interface IRepositoryOAuth : IRepositoryBase<object>
{
    Task<OAuthClients> FindUserForLogin(string username, string password);
}

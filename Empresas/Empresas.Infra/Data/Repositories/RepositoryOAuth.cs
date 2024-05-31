using Empresas.Domain;
using Empresas.Domain.Entities.OAuth;
using Empresas.Infra.Data;
using Empresas.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Empresas.Infra;

public class RepositoryOAuth : RepositoryBase<object>, IRepositoryOAuth
{
    private readonly EmpresaContext context;

    public RepositoryOAuth(EmpresaContext context) : base(context) => this.context = context;

    public async Task<OAuthClients> FindUserForLogin(string username, string password)
    {
        var user = await context.OAuthClients
            .Include(a => a.OAuthClientSecrets)
            .Include(a => a.OAuthClientGrantTypes)
            .Include(a => a.OAuthClientScopes)
            .ThenInclude(s => s.Scope)
            .FirstOrDefaultAsync(a => a.ClientId == username && a.OAuthClientSecrets.Any(b => b.Value == password));

        return user;
    }
}

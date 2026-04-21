using Microsoft.AspNetCore.Authorization;

namespace Projeto_Alura.Infrastructure.Auth;

public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequeriment>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequeriment requirement)
    {
        if (context.User.HasClaim(c => c.Type == "Role" && c.Value == requirement.Role))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}

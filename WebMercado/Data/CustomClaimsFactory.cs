using WebMercado.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebMercado.Data
{
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<Usuario>
    {
        public CustomClaimsFactory(UserManager<Usuario> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Usuario user)
        {
            var roles = await UserManager.GetRolesAsync(user);
            user.Roles = string.Join(", ", roles);
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Nome", user.Nome));
            identity.AddClaim(new Claim("Apelido", user.Apelido));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Roles));
            return identity;
        }
    }
}

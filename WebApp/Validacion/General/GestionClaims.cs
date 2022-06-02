namespace WebApp.Validacion.General
{
    using WebApp.Models.General;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;

    public class GestionClaims
    {
        private ClaimsPrincipal ClaimsPrincipal;

        public GestionClaims()
        {

        }

        public GestionClaims(ClaimsPrincipal _claimsPrincipal)
        {
            ClaimsPrincipal = _claimsPrincipal;
        }

        private string ObtenerClaim(string _identificador)
        {
            string valor = null;

            valor = (from claim in ClaimsPrincipal.Identities.ToList()[0].Claims
                     where claim.Type == _identificador
                     select claim).FirstOrDefault().Value;

            return valor;
        }

        private string[] ObtenerClaimRoles(string _identificador)
        {
            return (from claim in ClaimsPrincipal.Claims
                    where claim.Type == _identificador
                    select claim.Value.ToString()).ToArray();
        }

        public string IdUsuario { get => ObtenerClaim(ClaimPersonalizadoDto.UsuarioEmpresarial); }
        public string Nombres { get => ObtenerClaim(ClaimPersonalizadoDto.Nombres); }
        public string Apellidos { get => ObtenerClaim(ClaimPersonalizadoDto.Apellidos); }
        public string Cargo { get => ObtenerClaim(ClaimPersonalizadoDto.Cargo); }
        public string[] Roles { get => ObtenerClaimRoles(ClaimPersonalizadoDto.Role); }

        public List<Claim> GenerarClaim(Usuario user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimPersonalizadoDto.UsuarioEmpresarial, user.UsuarioEmpresarial));
            claims.Add(new Claim(ClaimPersonalizadoDto.Nombres, user.Nombres));
            claims.Add(new Claim(ClaimPersonalizadoDto.Apellidos, user.Apellidos));
            claims.Add(new Claim(ClaimPersonalizadoDto.Cargo, user.Cargo));

            foreach (var item in user.LstRoles)
            {
                claims.Add(new Claim(ClaimPersonalizadoDto.Role, item));
            }

            return claims;
        }
    }
}

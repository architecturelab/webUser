namespace WebApp.Controllers
{
    using WebApp.Models.General;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApp.Validacion.General;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CuentaController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Usuario, Clave")] ModeloLoginDto _modelLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(_modelLogin);
            }

            GestionUsuario gestionUsuario = new GestionUsuario();

            if (!gestionUsuario.LstUsuario.Any(s => s.UsuarioEmpresarial.Equals(_modelLogin.Usuario) && s.Clave.Equals(_modelLogin.Clave)))
            {
                ModelState.AddModelError("ErrorLogin", "Valide Usuario y/o Contraseña.");

                return View(_modelLogin);
            }

            var usuarioObtenido = gestionUsuario.LstUsuario.FirstOrDefault(s => s.UsuarioEmpresarial.Equals(_modelLogin.Usuario));

            var claimsIdentity = new ClaimsIdentity(new GestionClaims().GenerarClaim(usuarioObtenido), CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,    
                IsPersistent = false,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                IssuedUtc = DateTimeOffset.Now,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

            return RedirectToAction("PaginaInicial", "Inicio");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CerrarSesion()
        {
            HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            return RedirectToAction("Login", "Cuenta");
        }
    }
}

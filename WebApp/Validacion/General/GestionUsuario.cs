using System.Collections.Generic;

namespace WebApp.Validacion.General
{
    public class GestionUsuario
    {
        #region Propiedades
        public List<Usuario> LstUsuario
        {
            get
            {
                return new List<Usuario>
            {
                new Usuario{
                    Nombres = "Admin",
                    Apellidos = "ArchitectureLab",
                    Cargo = "Administrador",
                    UsuarioEmpresarial = "admin",
                    LstRoles = new List<string>{
                        "Administrador"
                    },
                    Clave = "1234"
                },
                new Usuario{
                    Nombres = "Aldedier",
                    Apellidos = "Martinez",
                    Cargo = "Analista Desarrollador",
                    UsuarioEmpresarial = "aldedier.martinez",
                    LstRoles = new List<string>{
                        "Diagnosticador"
                    },
                    Clave = "1234"
                },
                new Usuario{
                    Nombres = "Fabio",
                    Apellidos = "Cañon",
                    Cargo = "Jefe Almacen",
                    UsuarioEmpresarial = "fabio.canon",
                    LstRoles = new List<string>{
                        "Almacenista"
                    },
                    Clave = "1234"

                },
                 new Usuario{
                    Nombres = "Manuel",
                    Apellidos = "Ballesteros",
                    Cargo = "Evaluador",
                    UsuarioEmpresarial = "manuel.ballesteros",
                    LstRoles = new List<string>{
                        "Evaluaciones"
                    },
                    Clave = "1234"
                },
                 new Usuario{
                    Nombres = "Walter",
                    Apellidos = "Guevara",
                    Cargo = "Reparador",
                    UsuarioEmpresarial = "walter.guevara",
                    LstRoles = new List<string>{
                        "Reparaciones"
                    },
                    Clave = "1234"
                }
            };
            }
        }
        #endregion
    }
}

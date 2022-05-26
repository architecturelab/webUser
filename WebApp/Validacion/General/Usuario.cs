namespace Web.Validacion.General
{
    using System.Collections.Generic;

    public class Usuario
    {

        public Usuario()
        {
            
        }

        #region Atributos
        //private string nombres;
        //private string apellidos;
        //private string cargo;
        //private string usuarioEmpresarial;
        //private List<string> lstRoles;
        #endregion

        #region Propiedades

        public List<Usuario> LstUsuario
        {
            get; set;
        }

        public string Nombres
        {
            get;
            set;
        }
        public string Apellidos
        {
            get; set;
        }
        public string Cargo
        {
            get; set;
        }
        public string UsuarioEmpresarial
        {
            get; set;
        }
        public List<string> LstRoles
        {
            get; set;
        }
        public string Clave { get; set; }
        #endregion

        #region Metodos

        #endregion
    }
}

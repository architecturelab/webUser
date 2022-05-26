namespace Web.Models.General
{
    using System.ComponentModel.DataAnnotations;

    public class ModeloLoginDto
    {
        #region Propiedades
        [Required(ErrorMessage = "El campo Usuario es requerido.")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es requerido.")]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }
        #endregion
    }
}

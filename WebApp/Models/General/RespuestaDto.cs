namespace Web.Models.General
{

    public class RespuestaDto<T>
    {
        #region Propiedades
        public EstadoOperacion Codigo { get; set; }
        public string Mensaje { get; set; }
        public bool Estado
        {
            get
            {
                if (this.Codigo != EstadoOperacion.Bueno)
                {
                    return false;
                }
                return true;
            }
        }
        public T Respuesta { get; set; }
        #endregion
    }
}

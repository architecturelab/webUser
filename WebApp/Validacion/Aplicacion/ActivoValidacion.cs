using Web.Models.Aplicacion;
using Web.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Validacion.Aplicacion
{
    public class ActivoValidacion
    {
        public async Task<string> ValidacionActivoAsync(ActivoDTO activoDTO)
        {
            if (activoDTO.CLASE_ID == 0)
                return "El campo clase es obligatorio";

            if (activoDTO.MARCA_ID == 0)
                return "El campo marca es obligatorio";

            if (activoDTO.MODELO_ID == 0)
                return "El campo modelo es obligatorio";

            if (string.IsNullOrEmpty(activoDTO.SERIAL))
                return "El campo serial es obligatorio";

            if (activoDTO.FECHA_INGRESO.Year < 2000)
                return "El campo fecha ingreso es obligatorio";

            if (activoDTO.FECHA_FINAL_GARANTIA.Year < 2000)
                return "El campo fecha final garantia es obligatorio";

            if (activoDTO.VALOR == 0)
                return "El campo valor es obligatorio";

            if (activoDTO.FECHA_BAJA.Year < 2000)
                return "El campo fecha baja es obligatorio";

            if (string.IsNullOrEmpty(activoDTO.ESTADO))
                return "El campo estado es obligatorio";

            if (string.IsNullOrEmpty(activoDTO.OBSERVACION))
                return "El campo observación es obligatorio";

            if (activoDTO.DEPENDENCIA_ID == 0)
                return "El campo dependencia es obligatorio";

            if (await new ServicioActivo().CrearActivo(activoDTO))
                return "El registro se agregó correctamente";
            else
                return "No se pudo guardar el registro";
        }

        public async Task<List<ActivoDTO>> ConsultarActivos()
        {
            return await new ServicioActivo().ConsultarActivos();
        }

        public async Task<ActivoDTO> ConsultarActivoPorId(int _id)
        {
            if (_id == 0)
                return new ActivoDTO();

            return await new ServicioActivo().ConsultarActivoPorId(_id);
        }

    }
}

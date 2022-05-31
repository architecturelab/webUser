using Web.Models.Aplicacion;
using Web.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Validacion.General;
using WebApp.Models.General;

namespace Web.Validacion.Aplicacion
{
    public class ActivoValidacion
    {
        public async Task<(bool, string)> ValidacionActivoAsync(ActivoDTO activoDTO)
        {
            if (activoDTO.claseId == 0)
                return (false, "El campo clase es obligatorio");

            if (activoDTO.marcaId == 0)
                return (false, "El campo marca es obligatorio");

            if (activoDTO.modeloId == 0)
                return (false, "El campo modelo es obligatorio");

            if (string.IsNullOrEmpty(activoDTO.serial))
                return (false, "El campo serial es obligatorio");

            if (activoDTO.fechaIngreso == null)
                return (false, "El campo fecha ingreso es obligatorio");

            if (activoDTO.fechaFinalGarantia == null)
                return (false, "El campo fecha final garantia es obligatorio");

            if (activoDTO.valor == 0)
                return (false, "El campo valor es obligatorio");

            //if (activoDTO.fechaBaja == null)
            //    return (false, "El campo fecha baja es obligatorio");

            if (string.IsNullOrEmpty(activoDTO.estado))
                return (false, "El campo estado es obligatorio");

            //if (string.IsNullOrEmpty(activoDTO.observacion))
            //    return (false, "El campo observación es obligatorio");

            if (activoDTO.dependenciaId == 0)
                return (false, "El campo dependencia es obligatorio");

            activoDTO.serial = activoDTO.serial.ToUpper();

            if (await new ServicioActivo().CrearActivo(activoDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public async Task<(bool, string)> ValidacionActivoActualizarAsync(ActivoDTO activoDTO)
        {
            if (activoDTO.claseId == 0)
                return (false, "El campo clase es obligatorio");

            if (activoDTO.marcaId == 0)
                return (false, "El campo marca es obligatorio");

            if (activoDTO.modeloId == 0)
                return (false, "El campo modelo es obligatorio");

            if (string.IsNullOrEmpty(activoDTO.serial))
                return (false, "El campo serial es obligatorio");

            if (activoDTO.fechaIngreso == null)
                return (false, "El campo fecha ingreso es obligatorio");

            if (activoDTO.fechaFinalGarantia == null)
                return (false, "El campo fecha final garantia es obligatorio");

            if (activoDTO.valor == 0)
                return (false, "El campo valor es obligatorio");

            //if (activoDTO.fechaBaja == null)
            //    return (false, "El campo fecha baja es obligatorio");

            if (string.IsNullOrEmpty(activoDTO.estado))
                return (false, "El campo estado es obligatorio");

            //if (string.IsNullOrEmpty(activoDTO.observacion))
            //    return (false, "El campo observación es obligatorio");

            if (activoDTO.dependenciaId == 0)
                return (false, "El campo dependencia es obligatorio");

            if (await new ServicioActivo().ActualizarActivo(activoDTO))
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public async Task<List<ActivoDTO>> ConsultarActivos()
        {
            return await new ServicioActivo().ConsultarActivos();
        }

        public async Task<ActivoDTO> ConsultarActivoPorId(int _id)
        {
            if (_id == 0)
                return new ActivoDTO();

            return await new ServicioActivo().ConsultarActivo(_id);
        }

    }
}

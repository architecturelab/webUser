using System.Collections.Generic;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
{
    public class ReparacionValidacion
    {
        public (bool, string, ReparacionDTO) ValidacionReparacionAsync(ReparacionDTO reparacionDTO)
        {
            if (reparacionDTO.activoId == 0)
                return (true, "El campo activoId es obligatorio", null);

            if (string.IsNullOrEmpty(reparacionDTO.description))
                return (true, "El campo descripcion es obligatorio", null);

            ReparacionDTO resultado = new ServicioReparacion().CrearReparacion(reparacionDTO);

            WorkFlowDTO workFlowDTO = new WorkFlowValidacion().ConsultarWorkFlowPorId(reparacionDTO.ticketId);
            workFlowDTO.estado = "Disponible";
            workFlowDTO.reparacionId = resultado.id;
            workFlowDTO.fechaReparacion = resultado.fechaCreacion;
            workFlowDTO.fechaCierre = resultado.fechaCreacion;
            workFlowDTO.usuarioModifica = resultado.usuarioCreacion;

            new WorkFlowValidacion().ValidacionWorkFlowActualizarAsync(workFlowDTO);

            if (resultado != null && workFlowDTO != null)
                return (true, "El registro se actualizó correctamente", resultado);
            else
                return (false, "No se pudo actualizar el registro", null);
        }

        public (bool, string, ReparacionDTO) ValidacionReparacionActualizarAsync(ReparacionDTO reparacionDTO)
        {
            if (reparacionDTO.id == 0)
                return (true, "El campo evaluationId es obligatorio", null);

            if (reparacionDTO.activoId == 0)
                return (false, "El campo activoId es obligatorio", null);

            if (string.IsNullOrEmpty(reparacionDTO.description))
                return (false, "El campo descripcion es obligatorio", null);

            var resultado = new ServicioReparacion().ActualizarReparacion(reparacionDTO);

            if (resultado != null)
                return (true, "El registro se actualizó correctamente", null);
            else
                return (false, "No se pudo actualizar el registro", null);
        }

        public List<ReparacionDTO> ConsultarReparaciones()
        {
            return new ServicioReparacion().ConsultarReparaciones();
        }

        public ReparacionDTO ConsultarReparacionPorId(int _id)
        {
            if (_id == 0)
                return new ReparacionDTO();

            ReparacionDTO reparacions = new ServicioReparacion().ConsultarReparacion(_id);

            return reparacions;
        }

    }
}

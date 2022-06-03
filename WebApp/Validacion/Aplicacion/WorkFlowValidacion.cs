using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
{
    public class WorkFlowValidacion
    {
        public (bool, string) ValidacionWorkFlowAsync(WorkFlowDTO workFlowDTO)
        {
            if (workFlowDTO.activoId == 0)
                return (false, "El campo activoId es obligatorio");

            workFlowDTO.estado = "Diagnostico";

            if (new ServicioWorkFlow().CrearWorkFlow(workFlowDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public (bool, string) ValidacionWorkFlowActualizarAsync(WorkFlowDTO workFlowDTO)
        {
            if (workFlowDTO.activoId == 0)
                return (false, "El campo activoId es obligatorio");

            WorkFlowDTO resultado = new ServicioWorkFlow().ActualizarWorkFlow(workFlowDTO);

            ActivoDTO activoDTO = new ActivoValidacion().ConsultarActivoPorId(resultado.activoId);
            activoDTO.estado = resultado.estado;
            activoDTO.usuarioModifica = resultado.usuarioCreacion;
            new ActivoValidacion().ValidacionActivoActualizarAsync(activoDTO);

            if (resultado.ticketId != 0)
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public List<WorkFlowDTO> ConsultarWorkFlows()
        {
            return new ServicioWorkFlow().ConsultarWorkFlows();
        }

        public WorkFlowDTO ConsultarWorkFlowPorId(int _id)
        {
            if (_id == 0)
                return new WorkFlowDTO();

            return new ServicioWorkFlow().ConsultarWorkFlow(_id);
        }

    }
}

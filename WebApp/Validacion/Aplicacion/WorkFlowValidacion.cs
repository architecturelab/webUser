using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
{
    public class WorkFlowValidacion
    {
        public async Task<(bool, string)> ValidacionWorkFlowAsync(WorkFlowDTO workFlowDTO)
        {
            if (workFlowDTO.activoId == 0)
                return (false, "El campo activoId es obligatorio");

            workFlowDTO.estado = "Diagnostico";

            if (await new ServicioWorkFlow().CrearWorkFlow(workFlowDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public async Task<(bool, string)> ValidacionWorkFlowActualizarAsync(WorkFlowDTO workFlowDTO)
        {
            if (workFlowDTO.activoId == 0)
                return (false, "El campo activoId es obligatorio");

            if (workFlowDTO.estado == "Diagnostico")
                workFlowDTO.estado = "Evaluación";
            else if (workFlowDTO.estado == "Evaluación")
                workFlowDTO.estado = "Reparación";
            else if (workFlowDTO.estado == "Reparación")
                workFlowDTO.estado = "Cerrado";

            if (await new ServicioWorkFlow().ActualizarWorkFlow(workFlowDTO))
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public async Task<List<WorkFlowDTO>> ConsultarWorkFlows()
        {
            return await new ServicioWorkFlow().ConsultarWorkFlows();
        }

        public async Task<WorkFlowDTO> ConsultarWorkFlowPorId(int _id)
        {
            if (_id == 0)
                return new WorkFlowDTO();

            return await new ServicioWorkFlow().ConsultarWorkFlow(_id);
        }

    }
}

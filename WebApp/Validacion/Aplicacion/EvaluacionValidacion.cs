using System.Collections.Generic;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
{
    public class EvaluacionValidacion
    {
        public (bool, string, EvaluacionDTO) ValidacionEvaluacionAsync(EvaluacionDTO evaluacionDTO)
        {
            if (evaluacionDTO.activoId == 0)
                return (true, "El campo activoId es obligatorio", null);

            if (evaluacionDTO.decision == null)
                return (true, "El campo decision es obligatorio", null);  

            if (string.IsNullOrEmpty(evaluacionDTO.descripcion))
                return (true, "El campo descripcion es obligatorio", null);

            var resultado = new ServicioEvaluacion().CrearEvaluacion(evaluacionDTO);

            if (resultado != null)
                return (true, "El registro se actualizó correctamente", resultado);
            else
                return (false, "No se pudo actualizar el registro", null);
        }

        public (bool, string, EvaluacionDTO) ValidacionEvaluacionActualizarAsync(EvaluacionDTO evaluacionDTO)
        {
            if (evaluacionDTO.evaluationId == 0)
                return (true, "El campo evaluationId es obligatorio", null);

            if (evaluacionDTO.activoId == 0)
                return (false, "El campo activoId es obligatorio", null);

            if (evaluacionDTO.decision == null)
                return (false, "El campo decision es obligatorio", null);

            if (string.IsNullOrEmpty(evaluacionDTO.descripcion))
                return (false, "El campo descripcion es obligatorio", null);

            var resultado = new ServicioEvaluacion().ActualizarEvaluacion(evaluacionDTO);

            if (resultado != null)
                return (true, "El registro se actualizó correctamente", null);
            else
                return (false, "No se pudo actualizar el registro", null);
        }

        public List<EvaluacionDTO> ConsultarEvaluacions()
        {
            return new ServicioEvaluacion().ConsultarEvaluaciones();
        }

        public EvaluacionDTO ConsultarEvaluacionPorId(int _id)
        {
            if (_id == 0)
                return new EvaluacionDTO();

            EvaluacionDTO evaluacions = new ServicioEvaluacion().ConsultarEvaluacion(_id);

            return evaluacions;
        }

    }
}

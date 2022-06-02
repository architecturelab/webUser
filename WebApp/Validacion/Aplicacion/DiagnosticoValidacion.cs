using System.Collections.Generic;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
{
    public class DiagnosticoValidacion
    {
        public (bool, string, DiagnosticoDTO) ValidacionDiagnosticoAsync(DiagnosticoDTO diagnosticoDTO)
        {
            if (diagnosticoDTO.activoId == 0)
                return (true, "El campo activoId es obligatorio", null);

            if (diagnosticoDTO.apto == null)
                return (true, "El campo apto es obligatorio", null);  
            
            if (diagnosticoDTO.reparacion == null)
                return (true, "El campo reparacion es obligatorio", null);

            if (string.IsNullOrEmpty(diagnosticoDTO.descripcion))
                return (true, "El campo descripcion es obligatorio", null);

            var resultado = new ServicioDiagnostico().CrearDiagnostico(diagnosticoDTO);

            if (resultado != null)
                return (true, "El registro se actualizó correctamente", resultado);
            else
                return (false, "No se pudo actualizar el registro", null);
        }

        public (bool, string, DiagnosticoDTO) ValidacionDiagnosticoActualizarAsync(DiagnosticoDTO diagnosticoDTO)
        {
            if (diagnosticoDTO.diagnosticId == 0)
                return (true, "El campo diagnosticId es obligatorio", null);

            if (diagnosticoDTO.activoId == 0)
                return (false, "El campo activoId es obligatorio", null);

            if (diagnosticoDTO.apto == null)
                return (false, "El campo apto es obligatorio", null);

            if (diagnosticoDTO.reparacion == null)
                return (false, "El campo reparacion es obligatorio", null);

            if (string.IsNullOrEmpty(diagnosticoDTO.descripcion))
                return (false, "El campo descripcion es obligatorio", null);

            var resultado = new ServicioDiagnostico().ActualizarDiagnostico(diagnosticoDTO);

            if (resultado != null)
                return (true, "El registro se actualizó correctamente", null);
            else
                return (false, "No se pudo actualizar el registro", null);
        }

        public List<DiagnosticoDTO> ConsultarDiagnosticos()
        {
            return new ServicioDiagnostico().ConsultarDiagnosticos();
        }

        public DiagnosticoDTO ConsultarDiagnosticoPorId(int _id)
        {
            if (_id == 0)
                return new DiagnosticoDTO();

            DiagnosticoDTO diagnosticos = new ServicioDiagnostico().ConsultarDiagnostico(_id);

            return diagnosticos;
        }

    }
}

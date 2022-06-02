using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
{
    public class DominioValidacion
    {
        public (bool, string) ValidacionEmpleadoAsync(EmpleadoDTO empleadoDTO)
        {
            if (string.IsNullOrEmpty(empleadoDTO.NOMBRE))
                return (false, "El campo nombres es obligatorio");

            if (string.IsNullOrEmpty(empleadoDTO.APELLIDOS))
                return (false, "El campo apellidos es obligatorio");

            if (empleadoDTO.IDENTIFICACION == 0)
                return (false, "El campo identificación es obligatorio");

            if (string.IsNullOrEmpty(empleadoDTO.CORREO))
                return (false, "El campo correo es obligatorio");

            if (string.IsNullOrEmpty(empleadoDTO.AREA))
                return (false, "El campo area es obligatorio");

            if (new ServicioDominio().CrearEmpleado(empleadoDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public (bool, string) ActualizarEmpleadoAsync(EmpleadoDTO empleadoDTO)
        {
            if (empleadoDTO.EMPLEADO_ID == 0)
                return (false, "El campo id es obligatorio");

            if (string.IsNullOrEmpty(empleadoDTO.NOMBRE))
                return (false, "El campo nombres es obligatorio");

            if (string.IsNullOrEmpty(empleadoDTO.APELLIDOS))
                return (false, "El campo apellidos es obligatorio");

            if (empleadoDTO.IDENTIFICACION == 0)
                return (false, "El campo identificación es obligatorio");

            if (string.IsNullOrEmpty(empleadoDTO.CORREO))
                return (false, "El campo correo es obligatorio");

            if (string.IsNullOrEmpty(empleadoDTO.AREA))
                return (false, "El campo area es obligatorio");

            if (new ServicioDominio().ActualizarEmpleado(empleadoDTO))
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public (bool, string) ValidacionDependenciaAsync(DependenciaDTO dependenciaDTO)
        {
            if (string.IsNullOrEmpty(dependenciaDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (new ServicioDominio().CrearDependencia(dependenciaDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public (bool, string) ActualizarDependenciaAsync(DependenciaDTO dependenciaDTO)
        {
            if (dependenciaDTO.dependenciaId == 0)
                return (false, "El campo id es obligatorio");

            if (string.IsNullOrEmpty(dependenciaDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(dependenciaDTO.vigente))
                return (false, "El campo vigente es obligatorio");

            if (new ServicioDominio().ActualizarDependencia(dependenciaDTO))
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public (bool, string) ValidacionClaseAsync(ClaseDTO claseDTO)
        {
            if (string.IsNullOrEmpty(claseDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(claseDTO.vidaUtil))
                return (false, "El campo vida útil es obligatorio");

            if (new ServicioDominio().CrearClase(claseDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public (bool, string) ActualizarClaseAsync(ClaseDTO claseDTO)
        {
            if (claseDTO.claseId == 0)
                return (false, "El campo id es obligatorio");

            if (string.IsNullOrEmpty(claseDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(claseDTO.vidaUtil))
                return (false, "El campo vida útil es obligatorio");

            if (string.IsNullOrEmpty(claseDTO.vigente))
                return (false, "El campo vigente es obligatorio");

            if (new ServicioDominio().ActualizarClase(claseDTO))
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public (bool, string) ValidacionMarcaAsync(MarcaDTO marcaDTO)
        {
            if (string.IsNullOrEmpty(marcaDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (new ServicioDominio().CrearMarca(marcaDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public (bool, string) ActualizarMarcaAsync(MarcaDTO marcaDTO)
        {
            if (marcaDTO.marcaId == 0)
                return (false, "El campo id es obligatorio");

            if (string.IsNullOrEmpty(marcaDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(marcaDTO.vigente))
                return (false, "El campo vigente es obligatorio");

            if (new ServicioDominio().ActualizarMarca(marcaDTO))
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public (bool, string) ValidacionModeloAsync(ModeloDTO modeloDTO)
        {
            if (modeloDTO.marcaId == 0)
                return (false, "El campo marca es obligatorio");

            if (string.IsNullOrEmpty(modeloDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (new ServicioDominio().CrearModelo(modeloDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public (bool, string) ActualizarModeloAsync(ModeloDTO modeloDTO)
        {
            if (modeloDTO.modeloId == 0)
                return (false, "El campo id es obligatorio");

            if (modeloDTO.marcaId == 0)
                return (false, "El campo marcaId es obligatorio");

            if (string.IsNullOrEmpty(modeloDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(modeloDTO.vigente))
                return (false, "El campo vigente es obligatorio");

            if (new ServicioDominio().ActualizarModelo(modeloDTO))
                return (true, "El registro se actualizó correctamente");
            else
                return (false, "No se pudo actualizar el registro");
        }

        public List<EmpleadoDTO> ConsultarEmpleados()
        {
            return new ServicioDominio().ConsultarEmpleados();
        }

        public DependenciaDTO ConsultarDependencia(int _id)
        {
            return new ServicioDominio().ConsultarDependencia(_id);
        }

        public List<DependenciaDTO> ConsultarDependencias()
        {
            return new ServicioDominio().ConsultarDependencias();
        }

        public ClaseDTO ConsultarClase(int _id)
        {
            return new ServicioDominio().ConsultarClase(_id);
        }

        public List<ClaseDTO> ConsultarClases()
        {
            return new ServicioDominio().ConsultarClases();
        }

        public MarcaDTO ConsultarMarca(int _id)
        {
            return new ServicioDominio().ConsultarMarca(_id);
        }

        public List<MarcaDTO> ConsultarMarcas()
        {
            return new ServicioDominio().ConsultarMarcas();
        }

        public ModeloDTO ConsultarModelo(int _id)
        {
            return new ServicioDominio().ConsultarModelo(_id);
        }

        public List<ModeloDTO> ConsultarModelos()
        {
            return new ServicioDominio().ConsultarModelos();
        }

    }
}

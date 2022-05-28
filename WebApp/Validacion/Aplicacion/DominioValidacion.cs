using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.Aplicacion;
using Web.Servicio;

namespace Web.Validacion.Aplicacion
{
    public class DominioValidacion
    {
        public async Task<(bool, string)> ValidacionEmpleadoAsync(EmpleadoDTO empleadoDTO)
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

            if (await new ServicioDominio().CrearEmpleado(empleadoDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public async Task<(bool, string)> ValidacionDependenciaAsync(DependenciaDTO dependenciaDTO)
        {
            if (string.IsNullOrEmpty(dependenciaDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (await new ServicioDominio().CrearDependencia(dependenciaDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public async Task<(bool, string)> ValidacionClaseAsync(ClaseDTO claseDTO)
        {
            if (string.IsNullOrEmpty(claseDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(claseDTO.vidaUtil))
                return (false, "El campo vida útil es obligatorio");

            if (await new ServicioDominio().CrearClase(claseDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public async Task<(bool, string)> ValidacionMarcaAsync(MarcaDTO marcaDTO)
        {
            if (string.IsNullOrEmpty(marcaDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(marcaDTO.vidaUtil))
                return (false, "El campo vida útil es obligatorio");

            if (await new ServicioDominio().CrearMarca(marcaDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public async Task<(bool, string)> ValidacionModeloAsync(ModeloDTO modeloDTO)
        {
            if (modeloDTO.marcaId == 0)
                return (false, "El campo marca es obligatorio");

            if (string.IsNullOrEmpty(modeloDTO.nombre))
                return (false, "El campo nombre es obligatorio");

            if (string.IsNullOrEmpty(modeloDTO.vidaUtil))
                return (false, "El campo vida útil es obligatorio");

            if (await new ServicioDominio().CrearModelo(modeloDTO))
                return (true, "El registro se agregó correctamente");
            else
                return (false, "No se pudo guardar el registro");
        }

        public async Task<List<EmpleadoDTO>> ConsultarEmpleados()
        {
            return await new ServicioDominio().ConsultarEmpleados();
        }

        public async Task<DependenciaDTO> ConsultarDependencia(int _id)
        {
            return await new ServicioDominio().ConsultarDependencia(_id);
        }

        public async Task<List<DependenciaDTO>> ConsultarDependencias()
        {
            return await new ServicioDominio().ConsultarDependencias();
        }

        public async Task<ClaseDTO> ConsultarClase(int _id)
        {
            return await new ServicioDominio().ConsultarClase(_id);
        }

        public async Task<List<ClaseDTO>> ConsultarClases()
        {
            return await new ServicioDominio().ConsultarClases();
        }

        public async Task<MarcaDTO> ConsultarMarca(int _id)
        {
            return await new ServicioDominio().ConsultarMarca(_id);
        }

        public async Task<List<MarcaDTO>> ConsultarMarcas()
        {
            return await new ServicioDominio().ConsultarMarcas();
        }

        public async Task<ModeloDTO> ConsultarModelo(int _id)
        {
            return await new ServicioDominio().ConsultarModelo(_id);
        }

        public async Task<List<ModeloDTO>> ConsultarModelos()
        {
            return await new ServicioDominio().ConsultarModelos();
        }

    }
}

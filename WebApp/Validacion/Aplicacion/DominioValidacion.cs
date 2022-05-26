using Web.Models.Aplicacion;
using Web.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Validacion.Aplicacion
{
    public class DominioValidacion
    {

        public async Task<string> ValidacionEmpleadoAsync(EmpleadoDTO empleadoDTO)
        {
            if (string.IsNullOrEmpty(empleadoDTO.NOMBRE))
                return "El campo nombres es obligatorio";

            if (string.IsNullOrEmpty(empleadoDTO.APELLIDOS))
                return "El campo apellidos es obligatorio";

            if (empleadoDTO.IDENTIFICACION == 0)
                return "El campo identificación es obligatorio";

            if (string.IsNullOrEmpty(empleadoDTO.CORREO))
                return "El campo correo es obligatorio";

            if (string.IsNullOrEmpty(empleadoDTO.AREA))
                return "El campo area es obligatorio";

            if (await new ServicioDominio().CrearEmpleado(empleadoDTO))
                return "El registro se agregó correctamente";
            else
                return "No se pudo guardar el registro";
        }

        public async Task<string> ValidacionDependenciaAsync(DependenciaDTO dependenciaDTO)
        {
            if (string.IsNullOrEmpty(dependenciaDTO.NOMBRE))
                return "El campo nombre es obligatorio";

            if (await new ServicioDominio().CrearDependencia(dependenciaDTO))
                return "El registro se agregó correctamente";
            else
                return "No se pudo guardar el registro";
        }

        public async Task<string> ValidacionClaseAsync(ClaseDTO claseDTO)
        {
            if (string.IsNullOrEmpty(claseDTO.NOMBRE))
                return "El campo nombre es obligatorio";

            if (await new ServicioDominio().CrearClase(claseDTO))
                return "El registro se agregó correctamente";
            else
                return "No se pudo guardar el registro";
        }

        public async Task<string> ValidacionMarcaAsync(MarcaDTO marcaDTO)
        {
            if (marcaDTO.CLASE_ID == 0)
                return "El campo clase es obligatorio";

            if (string.IsNullOrEmpty(marcaDTO.NOMBRE))
                return "El campo nombre es obligatorio";

            if (await new ServicioDominio().CrearMarca(marcaDTO))
                return "El registro se agregó correctamente";
            else
                return "No se pudo guardar el registro";
        }

        public async Task<string> ValidacionModeloAsync(ModeloDTO modeloDTO)
        {
            if (modeloDTO.MARCA_ID == 0)
                return "El campo marca es obligatorio";

            if (string.IsNullOrEmpty(modeloDTO.NOMBRE))
                return "El campo nombre es obligatorio";

            if (modeloDTO.VIDA_UTIL == 0)
                return "El campo vida útil es obligatorio";

            if (await new ServicioDominio().CrearModelo(modeloDTO))
                return "El registro se agregó correctamente";
            else
                return "No se pudo guardar el registro";
        }

        public async Task<List<EmpleadoDTO>> ConsultarEmpleados()
        {
            return await new ServicioDominio().ConsultarEmpleados();
        }

        public async Task<List<DependenciaDTO>> ConsultarDependencias()
        {
            return await new ServicioDominio().ConsultarDependencias();
        }

        public async Task<List<ClaseDTO>> ConsultarClases()
        {
            return await new ServicioDominio().ConsultarClases();
        }

        public async Task<List<MarcaDTO>> ConsultarMarcas()
        {
            return await new ServicioDominio().ConsultarMarcas();
        }

        public async Task<List<ModeloDTO>> ConsultarModelos()
        {
            return await new ServicioDominio().ConsultarModelos();
        }

    }
}

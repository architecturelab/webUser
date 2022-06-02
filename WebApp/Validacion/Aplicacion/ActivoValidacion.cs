using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
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
            var activos = new ServicioActivo().ConsultarActivos();
            var clases = new ServicioDominio().ConsultarClases();
            var marcas = new ServicioDominio().ConsultarMarcas();
            var modelos = new ServicioDominio().ConsultarModelos();
            var dependencias = new ServicioDominio().ConsultarDependencias();

            await Task.WhenAll(activos, clases, marcas, modelos, dependencias);

            return (from x in activos.Result
                    join y in clases.Result on x.claseId equals y.claseId
                    join z in marcas.Result on x.marcaId equals z.marcaId
                    join a in modelos.Result on x.modeloId equals a.modeloId
                    join b in dependencias.Result on x.dependenciaId equals b.dependenciaId
                    select new ActivoDTO
                    {
                        itemId = x.itemId,
                        claseId = x.claseId,
                        claseIdStr = y.nombre,
                        dependenciaId = x.dependenciaId,
                        dependenciaIdStr = b.nombre,
                        estado = x.estado,
                        fechaBaja = x.fechaBaja,
                        fechaCreacion = x.fechaCreacion,
                        fechaFinalGarantia = x.fechaFinalGarantia,
                        fechaIngreso = x.fechaIngreso,
                        marcaId = x.marcaId,
                        marcaIdStr = z.nombre,
                        modeloId = x.modeloId,
                        modeloIdStr = a.nombre,
                        observacion = x.observacion,
                        serial = x.serial,
                        usuarioCreacion = x.usuarioCreacion,
                        valor = x.valor
                    }).ToList();
        }

        public async Task<ActivoDTO> ConsultarActivoPorId(int _id)
        {
            if (_id == 0)
                return new ActivoDTO();

            ActivoDTO activos = await new ServicioActivo().ConsultarActivo(_id);
            var clases = new ServicioDominio().ConsultarClase(activos.claseId);
            var marcas = new ServicioDominio().ConsultarMarca(activos.marcaId);
            var modelos = new ServicioDominio().ConsultarModelo(activos.modeloId);
            var dependencias = new ServicioDominio().ConsultarDependencia(activos.dependenciaId);

            await Task.WhenAll(clases, marcas, modelos, dependencias);

            activos.claseIdStr = clases.Result.nombre;
            activos.marcaIdStr = marcas.Result.nombre;
            activos.modeloIdStr = modelos.Result.nombre;
            activos.dependenciaIdStr = dependencias.Result.nombre;

            return activos;
        }

    }
}

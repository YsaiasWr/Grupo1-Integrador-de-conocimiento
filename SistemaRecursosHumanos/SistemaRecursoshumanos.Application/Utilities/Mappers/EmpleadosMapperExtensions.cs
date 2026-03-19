using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursoshumanos.Application.Models;
using System.Security.Cryptography.X509Certificates;

namespace SistemaRecursoshumanos.Application.Utilities.Mappers
{
    public static class EmpleadosMapperExtensions
    {
        public static EmpleadoModel ToModel(this Empleados entity)
            => new()
            {
                Idempleado = entity.Idempleado,
                Tipoempleado = entity.Tipoempleado,
                Documento = entity.Documento,
                NombreCompleto = entity.NombreCompleto,
                Telefono = new TelefonoVO(entity.Telefono),
                Correo = entity.Correo,
                Genero = entity.Genero,
                Direccion = entity.Direccion,
                Estado = entity.Estado,
                oDepartamento = entity.oDepartamento,
                oCargo = entity.oCargo,
                FechaNacimiento = entity.FechaNacimiento,
                Cargo = entity.Cargo,
                FechaIngreso = entity.FechaIngreso,
                Salario = entity.Salario,
                Horario = entity.Horario,
                Horas = entity.Horas,
                Imagen = entity.Imagen,

            };
        public static Empleados ToEntity (this EmpleadoModel model)
        {
            
                 return new Empleados(
                tipoempleado: model.Tipoempleado,
                documento: model.Documento,
                nombrecompleto: model.NombreCompleto,
                telefono: model.Telefono.Valor,
                correo: model.Correo,
                genero: model.Genero,
                direccion: model.Direccion,
                estado: model.Estado,
                Odepartamento: model.oDepartamento,
                ocargo: model.oCargo,
                fechanacimiento: model.FechaNacimiento,
                cargo: model.Cargo,
                fechaingreso: model.FechaIngreso,
                salario: model.Salario,
                horario: model.Horario,
                horas: model.Horas,
                imagen: model.Imagen




                 );
            
        }

        public static IReadOnlyList<EmpleadoModel> ToModels(this IReadOnlyList<Empleados> entities)
            => entities.Select(e => e.ToModel()).ToList();
        public static IReadOnlyList<Empleados> ToModels(this IReadOnlyList<EmpleadoModel> models)
            => models.Select(m => m.ToEntity()).ToList();

    }
}

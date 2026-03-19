using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursosHumanos.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Empleados
    {
        //Propiedades
        public Guid Idempleado { get; private set; }
        public string Tipoempleado { get; set; } = null!;
        public DocumentoVO Documento { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public TelefonoVO Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public Departamento oDepartamento { get; set; }
        public Cargo oCargo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Cargo { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public decimal Salario { get; set; }
        public string Horario { get; set; } = null!;
        public string Horas { get; set; } = null!;
        public byte[] Imagen { get; set; }

        //constructores
        public Empleados(string tipoempleado, DocumentoVO documento, string nombrecompleto,
            TelefonoVO telefono, string correo, string genero, string direccion, string estado, Departamento oDepartamento, Cargo oCargo,
            DateTime fechanacimiento, string cargo, DateTime fechaingreso, decimal salario, string horario, string horas, byte[] imagen)
        {
            // VALIDACIÓN: usar el parámetro recibido, no la propiedad
            if (string.IsNullOrWhiteSpace(nombrecompleto))
            {
                throw new ExcepcionReglaNegocio("El Nombre no puede estar vacio");
            }

            Idempleado = Guid.CreateVersion7();
            Tipoempleado = tipoempleado;
            Documento = documento;
            NombreCompleto = nombrecompleto;
            Telefono = telefono;
            Correo = correo;
            Genero = genero;
            Direccion = direccion;
            Estado = estado;
            this.oDepartamento = oDepartamento;
            this.oCargo = oCargo;
            FechaNacimiento = fechanacimiento;
            Cargo = cargo;
            FechaIngreso = fechaingreso;    // CORRECCIÓN: asignar FechaIngreso correctamente
            Salario = salario;
            Horario = horario;
            Horas = horas;
            Imagen = imagen;
        }

        //metodos
    }
}

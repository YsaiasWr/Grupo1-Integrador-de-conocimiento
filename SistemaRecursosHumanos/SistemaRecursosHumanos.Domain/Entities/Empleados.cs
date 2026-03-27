using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursosHumanos.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Entities
{
    // 🔹 Constructor vacío para EF Core
    
    public class Empleados
    {
        // 🔹 Constructor vacío para EF Core
        private Empleados() { }
        public Guid IdEmpleado { get; private set; }

        public string TipoEmpleado { get; private set; } = null!;
        public DocumentoVO Documento { get; private set; } = null!;
        public string NombreCompleto { get; private set; } = null!;
        public TelefonoVO Telefono { get; private set; } = null!;
        public string Correo { get; private set; } = null!;
        public string Genero { get; private set; } = null!;
        public string Direccion { get; private set; } = null!;
        public string Estado { get; private set; } = null!;

        public DateTime FechaNacimiento { get; private set; }
        public DateTime FechaIngreso { get; private set; }
        public decimal Salario { get; private set; }

        public string Horario { get; private set; } = null!;
        public string Horas { get; private set; } = null!;
        public byte[]? Imagen { get; private set; }

        // Relaciones
        public Guid IdDepartamento { get; private set; }
        public Departamento Departamento { get; private set; } = null!;

        public Guid IdCargo { get; private set; }
        public Cargo Cargo { get; private set; } = null!;

        // Relación inversa
        public ICollection<Asistencia> Asistencias { get; private set; } = new List<Asistencia>();

        // Constructor
        public Empleados(
            string tipoEmpleado,
            DocumentoVO documento,
            string nombreCompleto,
            TelefonoVO telefono,
            string correo,
            string genero,
            string direccion,
            string estado,
            Guid idDepartamento,
            Guid idCargo,
            DateTime fechaNacimiento,
            DateTime fechaIngreso,
            decimal salario,
            string horario,
            string horas,
            byte[]? imagen)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto))
                throw new ExcepcionReglaNegocio("El nombre no puede estar vacío");

            if (salario <= 0)
                throw new ExcepcionReglaNegocio("El salario debe ser mayor que 0");

            IdEmpleado = Guid.NewGuid();

            TipoEmpleado = tipoEmpleado;
            Documento = documento;
            NombreCompleto = nombreCompleto;
            Telefono = telefono;
            Correo = correo;
            Genero = genero;
            Direccion = direccion;
            Estado = estado;

            IdDepartamento = idDepartamento;
            IdCargo = idCargo;

            FechaNacimiento = fechaNacimiento;
            FechaIngreso = fechaIngreso;
            Salario = salario;
            Horario = horario;
            Horas = horas;
            Imagen = imagen;
        }
    }
}
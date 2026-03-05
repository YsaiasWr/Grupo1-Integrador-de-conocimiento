using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Models
{
    public class EmpleadoModel
    {
        public Guid? Idempleado { get; set; }
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

    }
}

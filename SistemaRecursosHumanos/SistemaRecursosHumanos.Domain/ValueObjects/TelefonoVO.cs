using SistemaRecursosHumanos.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.ObjectsValues
{
    
        public sealed record TelefonoVO
    {
        public string Valor { get; }
        public TelefonoVO(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ExcepcionReglaNegocio("El Telefono no puede estar vacio");
            }
            else if (valor.Length != 10)
            {
                throw new ExcepcionReglaNegocio("El Documento debe tener exactamente 10 caracteres");
            }
            Valor = valor;
        }
    }
}

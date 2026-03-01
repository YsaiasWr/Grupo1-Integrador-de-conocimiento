using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRecursosHumanos.Domain.Exceptions;

namespace SistemaRecursosHumanos.Domain.ObjectsValues

{
    public sealed record DocumentoVO
    {
        public string Valor { get; }
        public DocumentoVO(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ExcepcionReglaNegocio("El Documento no puede estar vacio");
            }
            else if (valor.Length != 11)
            {
                throw new ExcepcionReglaNegocio("El Documento debe tener exactamente 11 caracteres");
            }
            Valor = valor;
        }

    }
}


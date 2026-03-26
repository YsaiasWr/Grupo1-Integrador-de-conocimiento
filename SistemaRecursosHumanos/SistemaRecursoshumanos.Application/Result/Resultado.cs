using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Result
{
    public class Resultado<T>
    {
        public bool EsExitoso { get;  }
        public int Codigo { get; }
        public string? ErrorMensaje { get; }
        public T? Datos { get;  }

        private Resultado(bool esExitoso, T? valor, string errorMensaje, int codigo) {
            EsExitoso = esExitoso;
            Datos = valor;
            ErrorMensaje = errorMensaje;
            Codigo = codigo;
        }
        public static Resultado<T> Exito(T valor) => new Resultado<T>(true, valor, string.Empty, 200);

        public static Resultado<T> Error(string mensaje) => new Resultado<T>(false, default, mensaje, 400);
        
    }
}

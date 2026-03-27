using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Result
{
    public class Resultado<T>
    {
        public bool EsExitoso { get; }
        public int Codigo { get; }
        public string? ErrorMensaje { get; }
        public T? Datos { get; }

        private Resultado(bool esExitoso, T? datos, string? errorMensaje, int codigo)
        {
            EsExitoso = esExitoso;
            Datos = datos;
            ErrorMensaje = errorMensaje;
            Codigo = codigo;
        }

        // 🔹 Métodos internos (base)
        public static Resultado<T> Exito(T datos)
            => new Resultado<T>(true, datos, null, 200);

        public static Resultado<T> Error(string mensaje, int codigo = 400)
            => new Resultado<T>(false, default, mensaje, codigo);
    }

    // 🔥 Helper para usar Resultado.Ok y Resultado.Fail
    public static class Resultado
    {
        public static Resultado<T> Ok<T>(T datos)
            => Resultado<T>.Exito(datos);

        public static Resultado<T> Fail<T>(string mensaje, int codigo = 400)
            => Resultado<T>.Error(mensaje, codigo);
    }
}
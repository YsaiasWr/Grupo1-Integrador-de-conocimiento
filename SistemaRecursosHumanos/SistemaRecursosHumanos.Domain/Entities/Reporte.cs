namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Reporte
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaGeneracion { get; set; }
        public string Contenido { get; set; } = string.Empty;
    }
}


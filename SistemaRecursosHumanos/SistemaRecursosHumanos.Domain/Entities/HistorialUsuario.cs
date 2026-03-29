namespace SistemaRecursosHumanos.Domain.Entities
{
    public class HistorialUsuario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Accion { get; set; } = string.Empty;
        public DateTime FechaAccion { get; set; }
    }
}

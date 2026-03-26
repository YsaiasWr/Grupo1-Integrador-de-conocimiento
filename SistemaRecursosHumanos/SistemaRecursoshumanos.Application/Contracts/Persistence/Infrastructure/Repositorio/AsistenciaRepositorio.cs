using System.Collections.Generic;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuProyecto.Data; // Aquí va tu DbContext
using TuProyecto.Models; // Aquí va tu entidad Asistencia

public class AsistenciaRepositorio : IAsistenciaRepositorio
{
    private readonly ApplicationDbContext _context;

    public AsistenciaRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    // Crear nueva asistencia
    public async Task CrearAsync(Asistencia asistencia)
    {
        await _context.Asistencias.AddAsync(asistencia);
        await _context.SaveChangesAsync();
    }

    // Obtener todas las asistencias
    public async Task<IEnumerable<Asistencia>> ObtenerTodasAsync()
    {
        return await _context.Asistencias.ToListAsync();
    }

    // Obtener asistencia por Id
    public async Task<Asistencia> ObtenerPorIdAsync(int id)
    {
        return await _context.Asistencias.FindAsync(id);
    }

    // Actualizar asistencia
    public async Task ActualizarAsync(Asistencia asistencia)
    {
        _context.Asistencias.Update(asistencia);
        await _context.SaveChangesAsync();
    }

    // Eliminar asistencia
    public async Task EliminarAsync(int id)
    {
        var asistencia = await _context.Asistencias.FindAsync(id);
        if (asistencia != null)
        {
            _context.Asistencias.Remove(asistencia);
            await _context.SaveChangesAsync();
        }
    }
}

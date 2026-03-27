
using Microsoft.EntityFrameworkCore;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Infrastructure.Data;
using System;
public class AsistenciaRepositorio : IAsistenciaRepositorio
{
    private readonly AppDbContext _context;

    public AsistenciaRepositorio(AppDbContext context)
    {
        _context = context;
    }

    // Crear nueva asistencia
    public async Task<Asistencia> AgregarAsync(Asistencia entidad, CancellationToken ct = default)
    {
        _context.Asistencias.Add(entidad);
        await _context.SaveChangesAsync(ct);
        return entidad;
    }

    // Obtener todas las asistencias
    public async Task<IReadOnlyList<Asistencia>> ObtenerTodosAsync(CancellationToken ct = default)
    {
        var lista = await _context.Asistencias.ToListAsync(ct);
        return lista ?? new List<Asistencia>(); // Por seguridad
    }

    // Obtener asistencia por Id
    public async Task<Asistencia?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Asistencias.FindAsync(new object[] { id }, ct);
    }

    // Actualizar asistencia
    public async Task<Asistencia> ActualizarAsync(Asistencia entidad, CancellationToken ct = default)
    {
        _context.Asistencias.Update(entidad);
        await _context.SaveChangesAsync(ct);
        return entidad;
    }

    // Eliminar asistencia
    public async Task<Asistencia> EliminarAsync(Asistencia entidad, CancellationToken ct = default)
    {
        _context.Asistencias.Remove(entidad);
        await _context.SaveChangesAsync(ct);
        return entidad;
    }








}

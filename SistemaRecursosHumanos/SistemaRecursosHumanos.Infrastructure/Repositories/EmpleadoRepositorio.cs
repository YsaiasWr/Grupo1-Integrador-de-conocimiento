using Microsoft.EntityFrameworkCore;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Infrastructure.Data;
using System;

public class EmpleadoRepositorio : IEmpleadoRepositorio
{
    private readonly AppDbContext _context;

    public EmpleadoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Empleados> AgregarAsync(Empleados entidad, CancellationToken ct = default)
    {
        _context.Empleado.Add(entidad);
        await _context.SaveChangesAsync(ct);
        return entidad;
    }

    public async Task<Empleados> ActualizarAsync(Empleados entidad, CancellationToken ct = default)
    {
        _context.Empleado.Update(entidad);
        await _context.SaveChangesAsync(ct);
        return entidad;
    }

    public async Task<Empleados> EliminarAsync(Empleados entidad, CancellationToken ct = default)
    {
        _context.Empleado.Remove(entidad);
        await _context.SaveChangesAsync(ct);
        return entidad;
    }

    public async Task<Empleados?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Empleado.FindAsync(new object[] { id }, ct);
    }

    public async Task<IReadOnlyList<Empleados>> ObtenerTodosAsync(CancellationToken ct = default)
    {
        return await _context.Empleado.ToListAsync(ct);
    }
}

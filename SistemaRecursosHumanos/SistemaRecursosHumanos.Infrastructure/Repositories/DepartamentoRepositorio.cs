using Microsoft.EntityFrameworkCore;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Infrastructure.Data;
using System;

namespace SistemaRecursosHumanos.Infrastructure.Repositories
{
    public class DepartamentoRepositorio : IDepartamento
    {
        
        private readonly AppDbContext _context;

        public DepartamentoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Departamento> AgregarAsync(Departamento entidad, CancellationToken ct = default)
        {
            _context.Departamentos.Add(entidad);
            await _context.SaveChangesAsync(ct);
            return entidad;
        }

        public async Task<Departamento> ActualizarAsync(Departamento entidad, CancellationToken ct = default)
        {
            _context.Departamentos.Update(entidad);
            await _context.SaveChangesAsync(ct);
            return entidad;
        }

        public async Task<Departamento> EliminarAsync(Departamento entidad, CancellationToken ct = default)
        {
            _context.Departamentos.Remove(entidad);
            await _context.SaveChangesAsync(ct);
            return entidad;
        }

        public async Task<Departamento?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Departamentos.FindAsync(new object[] { id }, ct);
        }

        public async Task<IReadOnlyList<Departamento>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            return await _context.Departamentos.ToListAsync(ct);
        }
    }
}


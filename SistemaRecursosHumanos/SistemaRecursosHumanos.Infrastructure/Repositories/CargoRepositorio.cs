using Microsoft.EntityFrameworkCore;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Infrastructure.Data;
using System;

namespace SistemaRecursosHumanos.Infrastructure.Repositories
{
    public class CargoRepositorio : ICargo

    {
        private readonly AppDbContext _context;

        public CargoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cargo> AgregarAsync(Cargo entidad, CancellationToken ct = default)
        {
            _context.Cargos.Add(entidad);
            await _context.SaveChangesAsync(ct);
            return entidad;
        }

        public async Task<Cargo> ActualizarAsync(Cargo entidad, CancellationToken ct = default)
        {
            _context.Cargos.Update(entidad);
            await _context.SaveChangesAsync(ct);
            return entidad;
        }

        public async Task<Cargo> EliminarAsync(Cargo entidad, CancellationToken ct = default)
        {
            _context.Cargos.Remove(entidad);
            await _context.SaveChangesAsync(ct);
            return entidad;
        }

        public async Task<Cargo?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Cargos.FindAsync(new object[] { id }, ct);
        }

        public async Task<IReadOnlyList<Cargo>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            return await _context.Cargos.ToListAsync(ct);
        }
    }
}

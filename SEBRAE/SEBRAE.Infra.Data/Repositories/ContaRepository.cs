using Microsoft.EntityFrameworkCore;
using SEBRAE.Domain.Entities;
using SEBRAE.Domain.Interfaces;
using SEBRAE.Infra.Data.Context;

namespace SEBRAE.Infra.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext contaContext)
        {
            _context = contaContext;
        }

        public async Task<Conta> CreateAsync(Conta conta)
        {
            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();
            return conta;
        }

        public async Task<Conta> GetByIdAsync(int? id)
        {
            return await _context.Contas.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Conta>> GetContasAsync()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Conta> UpdateAsync(Conta conta)
        {
            _context.Update(conta);
            await _context.SaveChangesAsync();
            return conta;
        }

        public async Task<Conta> RemoveAsync(Conta conta)
        {
            _context.Remove(conta);
            await _context.SaveChangesAsync();
            return conta;
        }        
    }
}

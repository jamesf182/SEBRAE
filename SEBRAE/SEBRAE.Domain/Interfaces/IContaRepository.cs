using SEBRAE.Domain.Entities;

namespace SEBRAE.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> GetContasAsync();
        Task<Conta> GetByIdAsync(int? id);
        Task<Conta> CreateAsync(Conta conta);
        Task<Conta> UpdateAsync(Conta conta);
        Task<Conta> RemoveAsync(Conta conta);
    }
}

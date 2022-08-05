using SEBRAE.Application.DTOs;

namespace SEBRAE.Application.Interfaces
{
    public interface IContaService
    {
        Task<IEnumerable<ContaDTO>> GetContas();
        Task<ContaDTO> GetById(int? id);
        Task Add(ContaDTO contaDTO);
        Task Update(ContaDTO contaDTO);
        Task Remove(int? id);
    }
}

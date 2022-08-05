using AutoMapper;
using SEBRAE.Application.DTOs;
using SEBRAE.Application.Interfaces;
using SEBRAE.Domain.Entities;
using SEBRAE.Domain.Interfaces;

namespace SEBRAE.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContaService(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContaDTO>> GetContas()
        {
            var contasEntity = await _contaRepository.GetContasAsync();
            return _mapper.Map<IEnumerable<ContaDTO>>(contasEntity);
        }

        public async Task<ContaDTO> GetById(int? id)
        {
            var contaEntity = _contaRepository.GetByIdAsync(id).Result;
            return _mapper.Map<ContaDTO>(contaEntity);
        }

        public async Task Add(ContaDTO contaDTO)
        {
            var contaEntity = _mapper.Map<Conta>(contaDTO);
            await _contaRepository.CreateAsync(contaEntity);
        }

        public async Task Update(ContaDTO contaDTO)
        {
            var contaEntity = _mapper.Map<Conta>(contaDTO);
            await _contaRepository.UpdateAsync(contaEntity);
        }

        public async Task Remove(int? id)
        {
            var contaEntity = _contaRepository.GetByIdAsync(id).Result;
            await _contaRepository.RemoveAsync(contaEntity);
        }
    }
}

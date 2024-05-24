using Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.API.Interfaces;

namespace TaskBoard.API.Service
{
    public class PrioridadeService : IPrioridadeService
    {
        private readonly IPrioridadeRepository _prioridadeRepository;
        public PrioridadeService(IPrioridadeRepository prioridadeRepository)
        {
            _prioridadeRepository = prioridadeRepository;
        }

        public async Task<List<NivelPrioridade>> ListPrioridades()
        {
            return await _prioridadeRepository.ListPrioridades();
        }
    }
}

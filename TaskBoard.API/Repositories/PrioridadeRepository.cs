using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoard.API.Interfaces;

namespace TaskBoard.API.Repositories
{
    public class PrioridadeRepository : IPrioridadeRepository
    {
        private readonly NivelPrioridade nivelPrioridade;
        public PrioridadeRepository()
        {
            
        }
        public async Task<List<NivelPrioridade>> ListPrioridades()
        {
            try {
                var prioridades = Enum.GetValues(typeof(NivelPrioridade));
                return new List<NivelPrioridade>(prioridades.Cast<NivelPrioridade>());
            }
            catch (Exception ex){ 
                throw new System.NotImplementedException("Erro: " + ex.Message);
            }
        }
    }
}

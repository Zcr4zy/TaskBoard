using Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.API.Interfaces
{
    public interface IPrioridadeRepository
    {
        public Task<List<NivelPrioridade>> ListPrioridades();
    }
}

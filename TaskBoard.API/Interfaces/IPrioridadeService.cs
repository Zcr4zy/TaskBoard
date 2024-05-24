using Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.API.Interfaces
{
    public interface IPrioridadeService
    {
        public Task<List<NivelPrioridade>> ListPrioridades();
    }
}

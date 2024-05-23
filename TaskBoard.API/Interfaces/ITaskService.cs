using Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.API.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TaskModel>> ListTasks();
        public Task<TaskModel> GetById(int id); 
        public Task<TaskModel> PostTask(TaskModel task);
        public Task<TaskModel> UpdateTask(TaskModel task);
        public Task<string> DeleteTask(int id);
    }
}

using Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.API.Interfaces;

namespace TaskBoard.API.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<List<TaskModel>> ListTasks()
        {
            return await _taskRepository.ListTasks();
        }
        
        public async Task<TaskModel> GetById(int id)
        {
            return await _taskRepository.GetById(id);
        }

        public async Task<TaskModel> PostTask(TaskModel taskModel)
        {
            return await _taskRepository.PostTask(taskModel);
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            return await _taskRepository.UpdateTask(task);
        }

        public async Task<string> DeleteTask(int id)
        {
            return await _taskRepository.DeleteTask(id);
        }
    }
}

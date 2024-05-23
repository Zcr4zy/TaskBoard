using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.API.Data;
using TaskBoard.API.Interfaces;

namespace TaskBoard.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _appDbContext;
        public TaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<TaskModel>> ListTasks()
        {
            try
            {
                var listaTasks = await _appDbContext.Tasks.ToListAsync();
                if(listaTasks.Count == 0)
                {
                    throw new System.Exception("ERRO! Não foi encontrado nenhuma tarefa!");
                }
                return listaTasks;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TaskModel> GetById(int id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    throw new System.Exception("ERRO! Não foi encontrado nenhuma tarefa com este Id --> "+ id +"");
                }
                var Task = await _appDbContext.Tasks.FirstOrDefaultAsync(i => i.TaskId == id);
                return Task;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TaskModel> PostTask(TaskModel taskModel)
        {
            try
            {
                if(taskModel == null)
                {
                    throw new System.Exception("Não foi recebido nenhuma tarefa nova, verifique os campos novamente e os corrija caso haja algum erro");
                }
                await _appDbContext.Tasks.AddAsync(taskModel);
                _appDbContext.SaveChanges();
                return taskModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            try
            {
                var taskDB = await _appDbContext.Tasks.FirstOrDefaultAsync(i => i.TaskId == task.TaskId);
                if(taskDB == null)
                {
                    throw new System.Exception("ERRO! Não foi encontrado nenhuma tarefa com este Id --> " + taskDB.TaskId + "");
                }
                taskDB.Nome = task.Nome;
                taskDB.Descricao = task.Descricao;
                taskDB.DataLimite = task.DataLimite;
                taskDB.IsComplete = task.IsComplete;
                taskDB.Prioridade = task.Prioridade;

                _appDbContext.Tasks.Update(taskDB);
                await _appDbContext.SaveChangesAsync();
                return taskDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<String> DeleteTask(int id)
        {
            try
            {
                var taskDB = await _appDbContext.Tasks.FirstOrDefaultAsync(i => i.TaskId == id);
                if (taskDB == null)
                {
                    throw new System.Exception("ERRO! Não foi encontrado nenhuma tarefa com este Id --> " + taskDB.TaskId + "");
                }
                string mensagem = $@"{taskDB.Nome} deletado com sucesso!";

                _appDbContext.Tasks.Remove(taskDB);
                await _appDbContext.SaveChangesAsync();
                return mensagem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

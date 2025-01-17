using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Use_Cases.Task
{
    public class RetrieveTask:IRetrieveTask
    {
        private readonly ITaskRepository taskRepository;
        public RetrieveTask(ITaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }

        public async Task<OperationResult> GetTaskByIDAsync(int id)
        {
            try
            {
                var task = await taskRepository.GetByIDAsync(id);
                if (task == null)
                {
                    return OperationResult.ErrorResult(OperationStatus.NotFound);
                }
                return OperationResult.SuccessResult(new TaskModel()
                {
                    Id = task.ID,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    StartDate = task.StartDate,
                    Title = task.Title,
                    Name = task.Name,
                    TblEmploeeID = task.TblEmploeeID,
                    IsCompleted = task.IsCompleted
                });
            }
            catch (Exception ex)
            {

                return OperationResult.ErrorResult(OperationStatus.Exception, ex.Message);
            }
           
        }

        public async Task<OperationResult> GetTasksAsync()
        {
            try
            {
                var list = await taskRepository.GetAllAsync();
                return OperationResult.SuccessResult(list.Select(x => new TaskModel()
                {
                    Id = x.ID,
                    Description = x.Description,
                    DueDate = x.DueDate,
                    StartDate = x.StartDate,
                    Title = x.Title,
                    Name = x.Name,
                    TblEmploeeID = x.TblEmploeeID,
                    IsCompleted = x.IsCompleted
                }).ToList());
            }
            catch (Exception ex)
            {
                return OperationResult.ErrorResult(OperationStatus.Exception, ex.Message);
            }
            
        }
    }
}

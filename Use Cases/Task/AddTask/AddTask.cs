
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UseCases;

namespace UseCases
{
    public class AddTask : IAddTask
    {
     
        private readonly ITaskRepository taskRepository;
        public AddTask(ITaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }
        public async Task<OperationResult> AddTaskAsync(NewTaskModel model)
        {
            try
            {
                var task = new TblTask(model.Name, model.Description, model.Title, model.StartDate, model.DueDate, model.TblEmploeeID);
                int newId = await taskRepository.CreateAsync(task);
                if (newId > 0)
                {
                    return OperationResult.SuccessResult(newId);
                }
                return OperationResult.ErrorResult(OperationStatus.Failure, "Unknown Error");
            }
            catch (Exception ex)
            {

                return OperationResult.ErrorResult(OperationStatus.Exception, ex.Message);
            }
          
        }
    }
}

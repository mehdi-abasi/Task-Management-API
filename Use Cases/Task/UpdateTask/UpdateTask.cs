
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UseCases
{
    public class UpdateTask : IUpdateTask
    {
        private readonly ITaskRepository taskRepository;
        public UpdateTask(ITaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }
        public async Task<OperationResult> UpdateAsync(UpdateTaskModel model)
        {
            try
            {
                var task = await taskRepository.GetByIDAsync(model.Id);
                if (task == null)
                {
                    return OperationResult.ErrorResult(OperationStatus.NotFound);
                }
                task.Update(model.Name, model.Description, model.Title, model.StartDate, model.DueDate, model.TblEmploeeID);
                await taskRepository.SaveAsync();
                return OperationResult.SuccessResult();
            }
            catch (Exception ex)
            {
                return OperationResult.ErrorResult(OperationStatus.Exception, ex.Message);
            }
          
        }
    }
}

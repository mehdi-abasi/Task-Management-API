using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UseCases;

namespace UseCases
{
    public class DeleteTask : IDeleteTask
    {
        private readonly ITaskRepository taskRepository;
        public DeleteTask(ITaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }

        public async Task<OperationResult> DeleteAsync(int Id)
        {
            try
            {
                var task = await taskRepository.GetByIDAsync(Id);
                if (task == null)
                {
                    return OperationResult.ErrorResult(OperationStatus.NotFound);
                }

                await taskRepository.DeleteAsync(task);
                return OperationResult.SuccessResult();
            }
            catch (Exception ex)
            {

                return OperationResult.ErrorResult(OperationStatus.Exception, ex.Message);
            }
           
        }
    }
}

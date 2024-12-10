using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UseCases
{
    public interface IRetrieveTask
    {
        Task<OperationResult> GetTaskByIDAsync(int id);
        Task<OperationResult> GetTasksAsync();
    }
}

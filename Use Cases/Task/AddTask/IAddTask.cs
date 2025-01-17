using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Use_Cases.Task;

namespace UseCases
{
    public interface IAddTask
    {
         Task<OperationResult> AddTaskAsync(NewTaskModel model);
    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ITaskRepository:IBaseRepository<TblTask>
    {
        Task FinishTask(int taskId);
    }
}

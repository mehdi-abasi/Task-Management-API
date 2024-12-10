using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.EFCore
{
    public class TaskRepository:BaseRepository<TblTask>,ITaskRepository
    {

        public TaskRepository(DatabaseContext dbContext):base(dbContext)
        {
        }

        public async Task FinishTask(int taskId)
        {
            TblTask task = await GetByIDAsync(taskId);
            task.FinishTask();
            await SaveAsync();
        }
    }
}

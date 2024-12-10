using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.EFCore
{
    public class EmploeeRepository : BaseRepository<TblEmploee>, IEmploeeRepository
    {
        public EmploeeRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
    
}

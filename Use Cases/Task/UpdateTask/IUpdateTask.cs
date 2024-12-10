﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UseCases
{
    public interface IUpdateTask
    {
        Task<OperationResult> UpdateAsync(UpdateTaskModel model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public enum OperationStatus
    {
        Success,
        NotFound,
        Failure,
        Exception
    }
    public class OperationResult
    {
        public string Message { get; set; }
        public OperationStatus Status { get; set; }
        public object? Data
        { get; set; }
        public static OperationResult ErrorResult(OperationStatus errorstatus,string message = "")
        {
            return new OperationResult { Status = errorstatus, Message = message, Data = default };

        }
        public static OperationResult SuccessResult(object data = null, string message = "")
        {
            return new OperationResult { Status = OperationStatus.Success, Message = message, Data = data };
        }
    }
}

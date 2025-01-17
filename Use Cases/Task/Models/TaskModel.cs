using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class NewTaskModel:BaseModel
    {
        
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int TblEmploeeID { get; set; }
    }
    public class TaskModel:NewTaskModel
    {
        public int Id { get; set; }
    }
   
}

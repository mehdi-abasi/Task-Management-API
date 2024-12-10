using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TblTask : BaseEntity
    {
        public TblTask(string name, string description, string title, DateTime startDate, DateTime dueDate, int tblEmploeeID) : base(name, description)
        {
            this.Title = title;
            this.IsCompleted = false;
            this.StartDate = startDate;
            this.DueDate = dueDate;
            this.TblEmploeeID = tblEmploeeID;
        }
        public string Title { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public int TblEmploeeID { get; private set; }
        public virtual TblEmploee TblEmploee { get; private set; }
        public void Update(string name, string description, string title, DateTime startDate, DateTime dueDate, int tblEmploeeID)
        {
            base.Update(name, description);
            this.Title = title;
            this.StartDate = startDate;
            this.DueDate=dueDate;
            this.TblEmploeeID=tblEmploeeID;
        }
        public void FinishTask()
        {
            this.IsCompleted = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TblEmploee:BaseEntity
    {
        public TblEmploee(string name,string description,bool isActive) :base(name, description) { 
            this.JoinDate = DateTime.Now;
            this.IsActive = isActive;
        }
        public void ChangeActivation(bool isActive)
        {
            this.IsActive = isActive;
        }
        public DateTime JoinDate { get;private set; }
        public bool IsActive { get; private set; }
        public virtual ICollection<TblTask> TblTasks { get;private set; }
        public void Update(string name, string description, bool isActive)
        {
            base.Update(name, description);
            this.IsActive = isActive;
        }
    }
}

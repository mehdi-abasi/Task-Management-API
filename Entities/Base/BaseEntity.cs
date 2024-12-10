using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseEntity
    {
        public BaseEntity(string name,string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public int ID { get;private set; }
        public string Name { get;private set; }
        public string Description { get;private set; }
        public void Update(string name,string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }

}

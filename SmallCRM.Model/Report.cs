using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Report:BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastExecutionDate { get; set; }
    }
}

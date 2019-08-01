using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
   public class Feed: BaseEntity
    {
        public string Message { get; set; }
        public string FilePath { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string SalesOpportunity {get;set;}
        public Guid TargetUser { get; set; }
    }
}

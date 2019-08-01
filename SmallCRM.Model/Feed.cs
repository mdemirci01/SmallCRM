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
        public Guid? DocumentId { get; set; }
        public virtual Document Document { get; set; }
        public bool IsRead { get; set; }
        public string TargetUser { get; set; }
    }
}

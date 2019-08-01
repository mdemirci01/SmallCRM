using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Activity:BaseEntity
    {
        public string ContactName { get; set; }
        public string Subject { get; set; }
        public CallReason? CallReason { get; set; }
        public RelatedRecord? RelatedRecord { get; set; }
        public CallDirection? CallDirection { get; set; }
        public CallDetail? CallDetail { get; set; }
        public CallResult? CallResult { get; set; }
    }
}

using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Opportunity:BaseEntity
    {
        public string Owner { get; set; } 
        public string Name { get; set; } 
        public Guid CompanyId { get; set; } 
        public virtual Company Company { get; set; }
        public OpportunityType? OpportunityType { get; set; }

        public string NextStep { get; set; }
        public Guid? LeadSourceId { get; set; }
        public virtual LeadSource LeadSource { get; set; }

        public Guid? ContactId { get; set; }
        public virtual Contact Contact { get; set; }


        public decimal Amount { get; set; }

        public DateTime CloseDate { get; set; }

        public OpportunityStage OpportunityStage { get; set; }

        public int Possibility { get; set; }

        public decimal ExpectedRevenue { get; set; }
        public Guid? CampaignSourceId { get; set; }
        public CampaignSource CampaignSource { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

    }
}

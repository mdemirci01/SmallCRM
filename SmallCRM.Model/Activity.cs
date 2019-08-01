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
        public Guid? ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public string Description { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTelephone { get; set; }
        public string CompanyWebsite { get; set; }
        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string OpportunityName { get; set; }
        public decimal? OpportunityAmount { get; set; }
        public DateTime OpportunityCloseDate { get; set; }
        public OpportunityType OpportunityType { get; set; }
        public OpportunityStage OpportunityStage { get; set; }
        public Guid? OpportunityId { get; set; }
        public virtual Opportunity Opportunity { get; set; }

        public string CampaignName { get; set; }

        public CampaignStatus? CampaignStatus { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get; set; }
        public decimal? CampaignExpectedRevenue { get; set; } //Beklenen ciro
        public Guid? CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}

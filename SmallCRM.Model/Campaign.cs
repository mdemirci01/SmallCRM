using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Campaign:BaseEntity
    {
        public string Owner { get; set; }
        public OpportunityType OpportunityType { get; set; }
        public Guid? CampaignStatusId { get; set; }
        public virtual CampaignStatus CampaignStatus { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? ExpectedRevenue { get; set; } //Beklenen ciro
        public decimal? Cost { get; set; } //Maliyet(Gerçekleşen masraf)
        public string SendPhoneNumbers { get; set; } //Gönderilen Numaralar
        public DateTime? EndDate { get; set; }
        public decimal? PlannedCost { get; set; } //Bütçelenmiş masraf
        public string ExpectedResponse { get; set; } //Beklenen tepki
        public string Description { get; set; }
    }
}

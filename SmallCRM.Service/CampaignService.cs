using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
   public class CampaignService:ICampaignService
    {
        private readonly IRepository<Campaign> campaignRepository;
        private readonly IUnitOfWork unitOfWork;

        public CampaignService(IRepository<Campaign> campaignRepository, IUnitOfWork unitOfWork)
        {
            this.campaignRepository = campaignRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return campaignRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var campaign = campaignRepository.Get(id);
            if (campaign != null)
            {
                campaignRepository.Delete(campaign);
                unitOfWork.SaveChanges();
            }
        }

        public Campaign Get(Guid id)
        {
            return campaignRepository.Get(id);
        }

        public IEnumerable<Campaign> GetAll()
        {
            return campaignRepository.GetAll();
        }

        public void Insert(Campaign campaign)
        {
            campaignRepository.Insert(campaign);
            unitOfWork.SaveChanges();
        }

        public void Update(Campaign campaign)
        {
            campaignRepository.Update(campaign);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICampaignService
    {
        IEnumerable<Campaign> GetAll();
        Campaign Get(Guid id);
        void Insert(Campaign campaign);
        void Update(Campaign campaign);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}


using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class CampaignSourceService : ICampaignSourceService
    {
        private readonly IRepository<CampaignSource> campaignSourceRepository;
        private readonly IUnitOfWork unitOfWork;
        public CampaignSourceService(IRepository<CampaignSource> campaignSourceRepository, IUnitOfWork unitOfWork)
        {
            this.campaignSourceRepository = campaignSourceRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return campaignSourceRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var campaignSource = campaignSourceRepository.Get(id);
            if (campaignSource != null)
            {
                campaignSourceRepository.Delete(campaignSource);
                unitOfWork.SaveChanges();
            }
        }


        public CampaignSource Get(Guid id)
        {
            return campaignSourceRepository.Get(id);
        }

        public IEnumerable<CampaignSource> GetAll()
        {
            return campaignSourceRepository.GetAll();
        }

        public void Insert(CampaignSource campaignSource)
        {
            campaignSourceRepository.Insert(campaignSource);
            unitOfWork.SaveChanges();
        }

        public void Update(CampaignSource campaignSource)
        {
            campaignSourceRepository.Update(campaignSource);
            unitOfWork.SaveChanges();
        }
    }
    public interface ICampaignSourceService
    {
        IEnumerable<CampaignSource> GetAll();
       CampaignSource Get(Guid id);
        void Insert(CampaignSource campaignSource);
        void Update(CampaignSource campaignSource);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

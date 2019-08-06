using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class LeadSourceService : ILeadSourceService
    {
        private readonly IRepository<LeadSource> leadSourceRepository;
        private readonly IUnitOfWork unitOfWork;

        public LeadSourceService(IRepository<LeadSource> leadSourceRepository,IUnitOfWork unitOfWork)
        {
            this.leadSourceRepository = leadSourceRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return leadSourceRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var leadSource = leadSourceRepository.Get(id);
            if (leadSource != null)
            {
                leadSourceRepository.Delete(leadSource);
                unitOfWork.SaveChanges();
            }
        }

        public LeadSource Get(Guid id)
        {
            return leadSourceRepository.Get(id);
        }

        public IEnumerable<LeadSource> GetAll()
        {
            return leadSourceRepository.GetAll();
        }

        public void Insert(LeadSource leadSource)
        {
            leadSourceRepository.Insert(leadSource);
            unitOfWork.SaveChanges();
        }

        public void Update(LeadSource leadSource)
        {
            leadSourceRepository.Update(leadSource);
            unitOfWork.SaveChanges();
        }
    }
    public interface ILeadSourceService
    {
        IEnumerable<LeadSource> GetAll();
        LeadSource Get(Guid id);
        void Insert(LeadSource leadSource);
        void Update(LeadSource leadSource);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

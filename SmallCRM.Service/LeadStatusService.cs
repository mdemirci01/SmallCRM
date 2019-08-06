using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallCRM.Data;
using SmallCRM.Model;

namespace SmallCRM.Service
{
    public class LeadStatusService : ILeadStatusService
    {
        private readonly IRepository<LeadStatus> leadStatusRepository;
        private readonly IUnitOfWork unitOfWork;

        public LeadStatusService(IRepository<LeadStatus> leadStatusRepository, IUnitOfWork unitOfWork)
        {
            this.leadStatusRepository = leadStatusRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return leadStatusRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var leadStatus = leadStatusRepository.Get(id);
            if (leadStatus != null)
            {
                leadStatusRepository.Delete(leadStatus);
                unitOfWork.SaveChanges();
            }
        }

        public LeadStatus Get(Guid id)
        {
            return leadStatusRepository.Get(id);
        }

        public IEnumerable<LeadStatus> GetAll()
        {
            return leadStatusRepository.GetAll();
        }

        public void Insert(LeadStatus leadStatus)
        {
            leadStatusRepository.Insert(leadStatus);
            unitOfWork.SaveChanges();
        }

        public void Update(LeadStatus leadStatus)
        {
            leadStatusRepository.Update(leadStatus);
            unitOfWork.SaveChanges();
        }
    }
    public interface ILeadStatusService
    {
        IEnumerable<LeadStatus> GetAll();
        LeadStatus Get(Guid id);
        void Insert(LeadStatus leadStatus);
        void Update(LeadStatus leadStatus);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

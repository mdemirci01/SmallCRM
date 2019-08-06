using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class OpportunityService : IOpportunityService
    {
        private readonly IRepository<Opportunity> opportunityRepository;
        private readonly IUnitOfWork unitOfWork;

        public OpportunityService(IRepository<Opportunity> opportunityRepository, IUnitOfWork unitOfWork)
        {
            this.opportunityRepository = opportunityRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return opportunityRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var opportunity = opportunityRepository.Get(id);
            if (opportunity != null)
            {
                opportunityRepository.Delete(opportunity);
                unitOfWork.SaveChanges();
            }
        }

        public Opportunity Get(Guid id)
        {
            return opportunityRepository.Get(id);
        }

        public IEnumerable<Opportunity> GetAll()
        {
            return opportunityRepository.GetAll();
        }

        public void Insert(Opportunity opportunity)
        {
            opportunityRepository.Insert(opportunity);
            unitOfWork.SaveChanges();
        }

        public void Update(Opportunity opportunity)
        {
            opportunityRepository.Update(opportunity);
            unitOfWork.SaveChanges();
        }
    }

    public interface IOpportunityService
    {
        IEnumerable<Opportunity> GetAll();
        Opportunity Get(Guid id);

        void Insert(Opportunity opportunity);
        void Update(Opportunity opportunity);
        void Delete(Guid id);

        bool Any(Guid id);
    }
}

using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    
    public class LeadService : ILeadService
    {
        private readonly IRepository<Lead> _leadRepository;
        private readonly IUnitOfWork _unitOfWork;
        public LeadService(IUnitOfWork unitOfWork,IRepository<Lead> leadRepository)
        {
            this._unitOfWork = unitOfWork;
            this._leadRepository = leadRepository;
        }
        public bool Any(Guid Id)
        {
            return _leadRepository.Any(x => x.Id == Id);
        }

        public void Delete(Guid Id)
        {
            var lead = _leadRepository.Get(Id);
            if (lead!=null)
            {
                _leadRepository.Delete(lead);
                _unitOfWork.SaveChanges();
            }

           
        }

        public Lead Get(Guid Id)
        {
            var getLead = _leadRepository.Get(Id);
            return getLead;
        }

        public IEnumerable<Lead> GetAll()
        {
            return _leadRepository.GetAll();
        }

        public void Insert(Lead lead)
        {
            _leadRepository.Insert(lead);
            _unitOfWork.SaveChanges();
        }

        public void Update(Lead lead)
        {
            _leadRepository.Update(lead);
            _unitOfWork.SaveChanges();
        }
    }

    public interface ILeadService
    {
        IEnumerable<Lead> GetAll();
        Lead Get(Guid Id);
        void Insert(Lead lead);
        void Update(Lead lead);
        void Delete(Guid Id);
        bool Any(Guid Id);


    }
}

using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class CompanyTypeService : ICompanyTypeService
    {
        private readonly IRepository<CompanyType> companyTypeRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyTypeService(IRepository<CompanyType> companyTypeRepository, IUnitOfWork unitOfWork)
        {
            this.companyTypeRepository = companyTypeRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return companyTypeRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var companyType = companyTypeRepository.Get(id);
            if (companyType != null)
            {
                companyTypeRepository.Delete(companyType);
                unitOfWork.SaveChanges();
            }
        }

        public CompanyType Get(Guid id)
        {
            return companyTypeRepository.Get(id);
        }

        public IEnumerable<CompanyType> GetAll()
        {
            return companyTypeRepository.GetAll();
        }

        public void Insert(CompanyType companyType)
        {
            companyTypeRepository.Insert(companyType);
            unitOfWork.SaveChanges();
        }

        public void Update(CompanyType companyType)
        {
            companyTypeRepository.Update(companyType);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICompanyTypeService
    {
        IEnumerable<CompanyType> GetAll();
        CompanyType Get(Guid id);
        void Insert(CompanyType companyType);
        void Update(CompanyType companyType);
        void Delete(Guid id);
        bool Any(Guid id);

    }
}

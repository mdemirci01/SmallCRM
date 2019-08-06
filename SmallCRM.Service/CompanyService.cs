using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> companyRepository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IRepository<Company> companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }


        public bool Any(Guid id)
        {
            return companyRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var company = companyRepository.Get(id);
            if (company!=null)
            {
                companyRepository.Delete(company);
                unitOfWork.SaveChanges();
            }
        }

        public Company Get(Guid id)
        {
            return companyRepository.Get(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return companyRepository.GetAll();
        }

        public void Insert(Company company)
        {
            companyRepository.Insert(company);
            unitOfWork.SaveChanges();

        }

        public void Update(Company company)
        {
            companyRepository.Update(company);
            unitOfWork.SaveChanges();
        }
    }


    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();
        Company Get(Guid id);
        void Insert(Company company);
        void Update(Company company);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

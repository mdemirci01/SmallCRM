using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CountryService(IRepository<Country> countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return countryRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var country = countryRepository.Get(id);
            if (country != null)
            {
                countryRepository.Delete(country);
                unitOfWork.SaveChanges();
            }
        }

        public Country Get(Guid id)
        {
            return countryRepository.Get(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return countryRepository.GetAll();
        }

        public void Insert(Country country)
        {
            countryRepository.Insert(country);
            unitOfWork.SaveChanges();
        }

        public void Update(Country country)
        {
            countryRepository.Update(country);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICountryService
    {
        IEnumerable<Country> GetAll();
        Country Get(Guid id);
        void Insert(Country country);
        void Update(Country country);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

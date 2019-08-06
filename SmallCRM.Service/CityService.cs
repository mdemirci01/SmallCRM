using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
   public class CityService:ICityService
    {
        private readonly IRepository<City> cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public CityService(IRepository<City> cityRepository, IUnitOfWork unitOfWork)
        {
            this.cityRepository = cityRepository;
            this.unitOfWork = unitOfWork;
        }


        public bool Any(Guid id)
        {
            return cityRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var city = cityRepository.Get(id);
            if (city != null)
            {
                cityRepository.Delete(city);
                unitOfWork.SaveChanges();
            }
        }

        public City Get(Guid id)
        {
            return cityRepository.Get(id);
        }

        public IEnumerable<City> GetAll()
        {
            return cityRepository.GetAll();
        }

        public void insert(City city)
        {
            cityRepository.Insert(city);
            unitOfWork.SaveChanges();
        }

        public void Update(City city)
        {
            cityRepository.Update(city);
            unitOfWork.SaveChanges();
        }
    }
    public interface ICityService
    {
        IEnumerable<City> GetAll();
        City Get(Guid id);
        void Insert(City city);
        void Update(City city);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}

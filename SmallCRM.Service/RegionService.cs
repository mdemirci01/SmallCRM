using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class RegionService : IRegionService
    {
        private readonly IRepository<Region> regionRepository;
        private readonly IUnitOfWork unitOfWork;
        public RegionService(IRepository<Region> regionRepository, IUnitOfWork unitOfWork)
        {
            this.regionRepository = regionRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return regionRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var region = regionRepository.Get(id);
            if (region != null)
            {
                regionRepository.Delete(region);
                unitOfWork.SaveChanges();
            }
        }

        public Region Get(Guid id)
        {
            return regionRepository.Get(id);
        }

        public IEnumerable<Region> GetAll()
        {
            return regionRepository.GetAll();
        }
        public IEnumerable<Region> GetAllByCityId(Guid cityId)
        {
            return regionRepository.GetAll(x => x.CityId == cityId, o => o.Name, false);
        }

        public void Insert(Region region)
        {
            regionRepository.Insert(region);
            unitOfWork.SaveChanges();
        }

        public void Update(Region region)
        {
            regionRepository.Update(region);
            unitOfWork.SaveChanges();
        }
    }
    public interface IRegionService
    {
        IEnumerable<Region> GetAll();
        IEnumerable<Region> GetAllByCityId(Guid cityId);
        Region Get(Guid id);
        void Insert(Region region);
        void Update(Region region);
        void Delete(Guid id);
        bool Any(Guid id);

    }
}

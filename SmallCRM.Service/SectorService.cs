using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class SectorService : ISectorService
    {
        private readonly IRepository<Sector> sectorRepository;
        private readonly IUnitOfWork unitOfWork;

        public SectorService(IRepository<Sector> sectorRepository , IUnitOfWork unitOfWork)
        {
            this.sectorRepository = sectorRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return sectorRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var sector = sectorRepository.Get(id);
            if (sector!= null)
            {
                sectorRepository.Delete(sector);
                unitOfWork.SaveChanges();
            }
        }

        public Sector Get(Guid id)
        {
            return sectorRepository.Get(id);
        }

        public IEnumerable<Sector> GetAll()
        {
            return sectorRepository.GetAll();
        }

        public void Insert(Sector sector)
        {
            sectorRepository.Insert(sector);
            unitOfWork.SaveChanges();
        }

        public void Update(Sector sector)
        {
            sectorRepository.Update(sector);
            unitOfWork.SaveChanges();
        }
    }
   
    public interface ISectorService
    {
        IEnumerable<Sector> GetAll();
        Sector Get(Guid id);
        void Insert(Sector sector);
        void Update(Sector sector);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class TimeSpendingService:ITimeSpendingService
    {
        private readonly IRepository<TimeSpending> timeSpendingRepository;
        private readonly IUnitOfWork unitOfWork;
        public TimeSpendingService(IRepository<TimeSpending> timeSpendingRepository, IUnitOfWork unitOfWork)
        {
            this.timeSpendingRepository = timeSpendingRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return timeSpendingRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var timeSpending = timeSpendingRepository.Get(id);
            if (timeSpending != null)
            {
                timeSpendingRepository.Delete(timeSpending);
                unitOfWork.SaveChanges();
            }
        }

        public TimeSpending Get(Guid id)
        {
            return timeSpendingRepository.Get(id);
        }

        public IEnumerable<TimeSpending> GetAll()
        {
            return timeSpendingRepository.GetAll();
        }

        public void Insert(TimeSpending timeSpending)
        {
            timeSpendingRepository.Insert(timeSpending);
            unitOfWork.SaveChanges();
        }

        public void Update(TimeSpending timeSpending)
        {
            timeSpendingRepository.Update(timeSpending);
            unitOfWork.SaveChanges();
        }
    }

    public interface ITimeSpendingService
    {
        IEnumerable<TimeSpending> GetAll();
        TimeSpending Get(Guid id);
        void Insert(TimeSpending timeSpending);
        void Update(TimeSpending timeSpending);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

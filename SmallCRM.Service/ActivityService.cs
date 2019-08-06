using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository<Activity> activityRepository;
        private readonly IUnitOfWork unitOfWork;
        public ActivityService(IRepository<Activity> activityRepository, IUnitOfWork unitOfWork)
        {
            this.activityRepository = activityRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return activityRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var activity = activityRepository.Get(id);
            if (activity != null)
            {
                activityRepository.Delete(activity);
                unitOfWork.SaveChanges();
            }

        }

        public Activity Get(Guid id)
        {
            return activityRepository.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return activityRepository.GetAll();
        }

        public void Insert(Activity activity)
        {
            activityRepository.Insert(activity);
            unitOfWork.SaveChanges();
        }

        public void Update(Activity activity)
        {
            activityRepository.Update(activity);
            unitOfWork.SaveChanges();
        }
    }

    public interface IActivityService
    {
        IEnumerable<Activity> GetAll();
        Activity Get(Guid id);
        void Insert(Activity activity);
        void Update(Activity activity);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

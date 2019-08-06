using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IRepository<WorkItem> _workItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public WorkItemService(IRepository<WorkItem> workItemRepository,IUnitOfWork unitOfWork)
        {
            this._workItemRepository = workItemRepository;
            this._unitOfWork = unitOfWork;
        }
        public bool Any(Guid Id)
        {
            return _workItemRepository.Any(x => x.Id == Id);
        }

        public void Delete(Guid Id)
        {
            var workItem = _workItemRepository.Get(Id);
            if (workItem!=null)
            {
                _workItemRepository.Delete(workItem);
                _unitOfWork.SaveChanges();
            }
        }

        public WorkItem Get(Guid Id)
        {
            var getWorkItem = _workItemRepository.Get(Id);
            return getWorkItem;
        }

        public IEnumerable<WorkItem> GetAll()
        {
            return _workItemRepository.GetAll();
        }

        public void Insert(WorkItem workItem)
        {
            _workItemRepository.Insert(workItem);
            _unitOfWork.SaveChanges();
        }

        public void Update(WorkItem workItem)
        {
            _workItemRepository.Update(workItem);
            _unitOfWork.SaveChanges();
        }
    }

    public interface IWorkItemService
    {
        IEnumerable<WorkItem> GetAll();
        WorkItem Get(Guid Id);
        void Insert(WorkItem workItem);
        void Update(WorkItem workItem);
        void Delete(Guid Id);
        bool Any(Guid Id);
    }
}

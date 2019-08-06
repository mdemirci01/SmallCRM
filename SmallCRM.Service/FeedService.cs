using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class FeedService:IFeedService
    {
        private readonly IRepository<Feed> feedRepository;
        private readonly IUnitOfWork unitOfWork;
        public FeedService(IRepository<Feed> feedRepository, IUnitOfWork unitOfWork)
        {
            this.feedRepository = feedRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return feedRepository.Any(x => x.Id == id);
        }
         

        public void Delete(Guid id)
        {
        var feed = feedRepository.Get(id);
        if (feed != null)
        {
            feedRepository.Delete(feed);
            unitOfWork.SaveChanges();
        }
        }

        public Feed Get(Guid id)
        {
            return feedRepository.Get(id);
        }

        public IEnumerable<Feed> GetAll()
        {
            return feedRepository.GetAll();
        }

        public void Insert(Feed feed)
        {
            feedRepository.Insert(feed);
            unitOfWork.SaveChanges();
        }

        public void Update(Feed feed)
        {
            feedRepository.Update(feed);
            unitOfWork.SaveChanges();
        }
    }
    public interface IFeedService
    {
        IEnumerable<Feed> GetAll();
        Feed Get(Guid id);
        void Insert(Feed feed);
        void Update(Feed feed);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report> reportRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReportService(IRepository<Report> reportRepository, IUnitOfWork unitOfWork)
        {
            this.reportRepository = reportRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return reportRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
           var report = reportRepository.Get(id);
            if (report != null)
            {
                reportRepository.Delete(report);
                unitOfWork.SaveChanges();
            }
        }

        public Report Get(Guid id)
        {
            return reportRepository.Get(id);
        }

        public IEnumerable<Report> GetAll()
        {
            return reportRepository.GetAll();

        }

        public void Insert(Report report)
        {
            reportRepository.Insert(report);
            unitOfWork.SaveChanges();
        }

        public void Update(Report report)
        {
            reportRepository.Update(report);
            unitOfWork.SaveChanges();
        }
    }

    public interface IReportService
    {
        IEnumerable<Report> GetAll();
        Report Get(Guid id);
        void Insert(Report report);
        void Update(Report report);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProjectService(IRepository<Project> projectRepository, IUnitOfWork unitOfWork)
        {
            this.projectRepository = projectRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return projectRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var project = projectRepository.Get(id);
            if (project != null)
            {
                projectRepository.Delete(project);
                unitOfWork.SaveChanges();
            }
        }

        public Project Get(Guid id)
        {
            return projectRepository.Get(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return projectRepository.GetAll();
        }

        public void Insert(Project project)
        {
            projectRepository.Insert(project);
            unitOfWork.SaveChanges();
        }

        public void Update(Project project)
        {
            projectRepository.Update(project);
            unitOfWork.SaveChanges();
        }
    }
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        Project Get(Guid id);
        void Insert(Project project);
        void Update(Project project);
        void Delete(Guid id);
        bool Any(Guid id);

    }
}

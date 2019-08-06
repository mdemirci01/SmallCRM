using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    public class DocumentService:IDocumentService
    {
        private readonly IRepository<Document> documentRepository;
        private readonly IUnitOfWork unitOfWork;

        public DocumentService(IRepository<Document> documentRepository, IUnitOfWork unitOfWork)
        {
            this.documentRepository = documentRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return documentRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var document = documentRepository.Get(id);
            if (document != null)
            {
                documentRepository.Delete(document);
                unitOfWork.SaveChanges();
            }
        }

        public Document Get(Guid id)
        {
            return documentRepository.Get(id);
        }

        public IEnumerable<Document> GetAll()
        {
            return documentRepository.GetAll();
        }

        public void Insert(Document document)
        {
            documentRepository.Insert(document);
            unitOfWork.SaveChanges();
        }

        public void Update(Document document)
        {
            documentRepository.Update(document);
            unitOfWork.SaveChanges();
        }
    }

    public interface IDocumentService
    {
        IEnumerable<Document> GetAll();
        Document Get(Guid id);
        void Insert(Document document);
        void Update(Document document);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}

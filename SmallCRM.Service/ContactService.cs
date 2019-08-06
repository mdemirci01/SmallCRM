using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmallCRM.Service.ContactService;

namespace SmallCRM.Service
{
    public class ContactService: IContactService
    {
        private readonly IRepository<Contact> contactRepository;
        private readonly IUnitOfWork unitOfWork;

        public ContactService(IRepository<Contact> contactRepository, IUnitOfWork unitOfWork)
        {
            this.contactRepository = contactRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return contactRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var contact = contactRepository.Get(id);
            if (contact != null)
            {
                contactRepository.Delete(contact);
                unitOfWork.SaveChanges();
            }
        }

        public Contact Get(Guid id)
        {
            return contactRepository.Get(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return contactRepository.GetAll();
        }

        public void Insert(Contact contact)
        {
            contactRepository.Insert(contact);
            unitOfWork.SaveChanges();
        }

        public void Update(Contact contact)
        {
            contactRepository.Update(contact);
            unitOfWork.SaveChanges();
        }

        
    }
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Contact Get(Guid id);
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(Guid id);
        bool Any(Guid id);
    }

}

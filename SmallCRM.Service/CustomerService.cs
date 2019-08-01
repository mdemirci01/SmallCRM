using SmallCRM.Data;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Service
{
    /*
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(IRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return customerRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var customer = customerRepository.Get(id);
            if (customer != null)
            {
                customerRepository.Delete(customer);
                unitOfWork.SaveChanges();
            }            
        }

        public Customer Get(Guid id)
        {
            return customerRepository.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public void Insert(Customer customer)
        {
            customerRepository.Insert(customer);
            unitOfWork.SaveChanges();
        }

        public void Update(Customer customer)
        {
            customerRepository.Update(customer);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer Get(Guid id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Guid id);
        bool Any(Guid id);
    }
    */
}

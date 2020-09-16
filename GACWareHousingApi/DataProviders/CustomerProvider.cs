using GACWareHousingApi.DBContext;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.DataProviders
{
    public class CustomerProvider : IDataRepository<Customer>
    {
        readonly GACWareHouseContext _context;
        public CustomerProvider(GACWareHouseContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        public Customer Get(long id)
        {
            return _context.Customers
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Customer Customer, Customer entity)
        {
            Customer.FirstName = entity.FirstName;
            Customer.LastName = entity.LastName;
            Customer.Email = entity.Email;
            Customer.PhoneNumber = entity.PhoneNumber;
            Customer.ModifiedBy = entity.ModifiedBy;
            Customer.ModifiedOn = DateTime.Now;
            Customer.IsDeleted = entity.IsDeleted;
            _context.SaveChanges();
        }
        public void Delete(Customer Customer)
        {
            _context.Customers.Remove(Customer);
            _context.SaveChanges();
        }
    }
}

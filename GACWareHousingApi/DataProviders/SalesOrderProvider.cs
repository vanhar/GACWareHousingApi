using GACWareHousingApi.DBContext;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.DataProviders
{
    public class SalesOrderProvider : IDataRepository<SalesOrder>
    {
        readonly GACWareHouseContext _context;
        public SalesOrderProvider(GACWareHouseContext context)
        {
            _context = context;
        }
        public IEnumerable<SalesOrder> GetAll()
        {
            return _context.SalesOrders.ToList();
        }
        public SalesOrder Get(long id)
        {
            return _context.SalesOrders
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(SalesOrder entity)
        {
            _context.SalesOrders.Add(entity);
            _context.SaveChanges();
        }
        public void Update(SalesOrder SalesOrder, SalesOrder entity)
        {
            SalesOrder.ModifiedBy = entity.ModifiedBy;
            SalesOrder.ModifiedOn = DateTime.Now;
            SalesOrder.IsDeleted = entity.IsDeleted;
            _context.SaveChanges();
        }
        public void Delete(SalesOrder SalesOrder)
        {
            _context.SalesOrders.Remove(SalesOrder);
            _context.SaveChanges();
        }
    }
}

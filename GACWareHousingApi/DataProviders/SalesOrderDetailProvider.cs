using GACWareHousingApi.DBContext;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.DataProviders
{
    public class SalesOrderDetailProvider : IDataRepository<SalesOrderDetail>
    {
        readonly GACWareHouseContext _context;
        public SalesOrderDetailProvider(GACWareHouseContext context)
        {
            _context = context;
        }
        public IEnumerable<SalesOrderDetail> GetAll()
        {
            return _context.SalesOrderDetails.ToList();
        }
        public SalesOrderDetail Get(long id)
        {
            return _context.SalesOrderDetails
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(SalesOrderDetail entity)
        {
            _context.SalesOrderDetails.Add(entity);
            _context.SaveChanges();
        }
        public void Update(SalesOrderDetail SalesOrderDetail, SalesOrderDetail entity)
        {
            SalesOrderDetail.Quantity = entity.Quantity;
            SalesOrderDetail.ModifiedBy = entity.ModifiedBy;
            SalesOrderDetail.ModifiedOn = DateTime.Now;
            SalesOrderDetail.IsDeleted = entity.IsDeleted;
            _context.SaveChanges();
        }
        public void Delete(SalesOrderDetail SalesOrderDetail)
        {
            _context.SalesOrderDetails.Remove(SalesOrderDetail);
            _context.SaveChanges();
        }
    }
}

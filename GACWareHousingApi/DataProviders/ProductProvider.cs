using GACWareHousingApi.DBContext;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.DataProviders
{
    public class ProductProvider : IDataRepository<Product>
    {
        readonly GACWareHouseContext _context;
        public ProductProvider(GACWareHouseContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product Get(long id)
        {
            return _context.Products
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Product Product, Product entity)
        {
            Product.ProductName = entity.ProductName;
            Product.UOM = entity.UOM;
            Product.Price = entity.Price;
            Product.ModifiedBy = entity.ModifiedBy;
            Product.ModifiedOn = DateTime.Now;
            Product.IsDeleted = entity.IsDeleted;
            _context.SaveChanges();
        }
        public void Delete(Product Product)
        {
            _context.Products.Remove(Product);
            _context.SaveChanges();
        }
    }
}

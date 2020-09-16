using GACWareHousingApi.DBContext;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.DataProviders
{
    public class ManfacturerProvider : IDataRepository<Manfacturer>
    {
        readonly GACWareHouseContext _context;
        public ManfacturerProvider(GACWareHouseContext context)
        {
            _context = context;
        }
        public IEnumerable<Manfacturer> GetAll()
        {
            return _context.Manfacturers.ToList();
        }
        public Manfacturer Get(long id)
        {
            return _context.Manfacturers
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(Manfacturer entity)
        {
            _context.Manfacturers.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Manfacturer Manfacturer, Manfacturer entity)
        {
            Manfacturer.FirstName = entity.FirstName;
            Manfacturer.LastName = entity.LastName;
            Manfacturer.Email = entity.Email;
            Manfacturer.PhoneNumber = entity.PhoneNumber;
            Manfacturer.ModifiedBy = entity.ModifiedBy;
            Manfacturer.ModifiedOn = DateTime.Now;
            Manfacturer.IsDeleted = entity.IsDeleted;
            _context.SaveChanges();
        }
        public void Delete(Manfacturer Manfacturer)
        {
            _context.Manfacturers.Remove(Manfacturer);
            _context.SaveChanges();
        }
    }
}

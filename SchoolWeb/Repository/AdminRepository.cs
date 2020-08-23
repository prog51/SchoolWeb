using SchoolWeb.Contracts;
using SchoolWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Repository
{
    public class AdminRepository : IAdminRepository
    {

        private readonly ApplicationDbContext _db;

        public AdminRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Organization entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Organization entity)
        {
            var DataValue = _db.Organizations.Remove(entity);
            return Save();
        }

        public ICollection<Organization> FindAll()
        {
            throw new NotImplementedException();
        }

        public Organization FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Value = _db.SaveChanges() > 0;
            return Value;
        }

        public bool Update(Organization entity)
        {
            var DataValue = _db.Organizations.Update(entity);
            return Save();
        }
    }
}

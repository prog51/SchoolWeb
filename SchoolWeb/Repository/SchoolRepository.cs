using SchoolWeb.Contracts;
using SchoolWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Repository
{
    public class SchoolRepository : ISchoolRepository
    {

        private readonly ApplicationDbContext _db;

        public SchoolRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(School entity)
        {
            var DataValue = _db.Schools.Add(entity);
            return Save();
        }

        public bool Delete(School entity)
        {
            var DataValue = _db.Schools.Remove(entity);
            return Save();
        }

        public ICollection<School> FindAll()
        {
            var DataValue = _db.Schools.ToList();
            return DataValue;
        }

        public School FindById(int id)
        {
            var DataValue = _db.Schools.Find(id);
            return DataValue;
        }

        public bool Save()
        {
            var Value = _db.SaveChanges() > 0;
            return Value;
        }

        public bool Update(School entity)
        {
            var DataValue = _db.Schools.Update(entity);
            return Save();
        }
    }
}

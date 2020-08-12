using SchoolWeb.Contracts;
using SchoolWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Repository
{
    public class RankRepository : IRankRepository
    {

        private readonly ApplicationDbContext _db;

        public RankRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Rank entity)
        {
            var NewData = _db.Ranks.Add(entity);
            return Save();
        }

        public bool Delete(Rank entity)
        {
            var DataRemove = _db.Ranks.Remove(entity);
            return Save();
        }

        public ICollection<Rank> FindAll()
        {
            var DataValues = _db.Ranks.ToList();
            return DataValues;

        }

        public Rank FindById(int id)
        {
            var DataValue = _db.Ranks.Find(id);
            return DataValue;
        }

        public bool isExists(int id)
        {
            var exists = _db.Ranks.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var Value = _db.SaveChanges() > 0;
            return Value;
        }

        public bool Update(Rank entity)
        {
            var NewValue = _db.Ranks.Update(entity);
            return Save();
        }
    }
}

using SchoolWeb.Contracts;
using SchoolWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Repository
{
    public class PlacementRepository : IPlacementRepository
    {

        private readonly ApplicationDbContext _db;

        public PlacementRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Placement entity)
        {
            var DataValue = _db.Placements.Add(entity);
            return Save();
        }

        public bool Delete(Placement entity)
        {
            var DataValue = _db.Placements.Remove(entity);
            return Save();
        }

        public ICollection<Placement> FindAll()
        {

            var DataValue = _db.Placements.ToList();
            return DataValue;
        }

        public Placement FindById(int id)
        {
            var DataValue = _db.Placements.Find(id);
            return DataValue;
        }

        public bool Save()
        {
            var Value = _db.SaveChanges() > 0;
            return Value;
        }

        public bool Update(Placement entity)
        {
            var DataValue = _db.Placements.Update(entity);
            return Save();
        }
    }
}

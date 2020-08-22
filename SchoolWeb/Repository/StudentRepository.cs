using SchoolWeb.Contracts;
using SchoolWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Student entity)
        {
            var DataValue = _db.Students.Add(entity);
            return Save();
        }

        public bool Delete(Student entity)
        {
            var DataValue = _db.Students.Remove(entity);
            return Save();
        }

        public ICollection<Student> FindAll()
        {
            var DataValue = _db.Students.ToList();
            return DataValue;
        }

        public Student FindById(int id)
        {
            var DataValue = _db.Students.Find(id);
            return DataValue;
        }

        public ICollection<School> FindSchools(int id)
        {

            var NewStudent = _db.Students.Find(id);

            var Score = NewStudent.Score;
            var Parish = NewStudent.Parish;
            var Schools = _db.Schools.Where(q => q.Parish == Parish && Score >= q.PassMark).ToList();
          

            return Schools;
        }

        public bool isExists(int id)
        {
            var exists = _db.Students.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var Value = _db.SaveChanges() > 0;
            return Value;
        }

        public bool Update(Student entity)
        {
            var DataValue = _db.Students.Update(entity);
            return Save();
        }

     }
}

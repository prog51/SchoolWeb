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
            throw new NotImplementedException();
        }

        public bool Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Student> FindAll()
        {
            throw new NotImplementedException();
        }

        public Student FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}

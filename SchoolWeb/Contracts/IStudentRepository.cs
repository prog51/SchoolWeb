﻿using SchoolWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Contracts
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        ICollection<School> FindSchools(int id);
        ICollection<Student> FindAll(string id);

    }
}

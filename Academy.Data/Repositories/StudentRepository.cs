using Academy.Core.Models;
using Academy.Core.Repositories;
using System;

namespace Academy.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public Task<List<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

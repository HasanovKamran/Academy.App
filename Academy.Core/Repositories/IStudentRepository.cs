using Academy.Core.Models;
using System;

namespace Academy.Core.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetAllAsync();
    }
}

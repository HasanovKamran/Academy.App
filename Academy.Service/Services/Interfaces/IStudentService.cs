using Academy.Core.Enum;
using System;

namespace Academy.Service.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullname, string group, int average, Education education);
        public Task<string> UpdateAsync(int id,string fullname, string group, int average, Education education);
        public Task<string> RemoveAsync(int id);
        public Task<string> GetAsync(int id);
        public Task GetAllAsync();
        void CreateAsync();
    }
}

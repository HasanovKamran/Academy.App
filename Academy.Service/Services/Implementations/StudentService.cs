using Academy.Core.Enum;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;
using Microsoft.VisualBasic;
using System;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository = new StudentRepository();
        private int id;
        public static Task CreateAsync(string? fullName, string? group, int average)
        {
            throw new NotImplementedException();
        }

        public static Task<string> CreateAsync(string? fullName, string? group, int average, Student enumIndex)
        {
            throw new NotImplementedException();
        }

        internal static Task<string> UpdateAsync(int id, string? fullName, string? group, int average, Student enumIndex)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateAsync(string fullname, string group, int average, Education education)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return "fullname can not be empty";

            if (string.IsNullOrWhiteSpace(group))
                return "group can not be empty";

            if (average < 0 && average > 100)
                return "0-100";
            Student student = new Student(fullname, group, average, education);
            student.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _studentRepository.AddAsync(student);
            return "Succesfully created";
        }

        public void CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GetAllAsync()
        {
            List<Student> students = await _studentRepository.GetAllAsync();
            foreach (Student student in students)
            {

                Console.WriteLine($"Id:{student.Id} fullname:{student.FullName}Group:{student.Group} average:{student.Average} Created:{student.CreatedAt} Updated:{student.UpdateAt}");

            }
        }

        public async Task<string> GetAsync(int id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found";
            Console.WriteLine($"Id:{student.Id} fullname:{student.FullName}Group:{student.Group} average:{student.Average} Created:{student.CreatedAt} Updated:{student.UpdateAt}");
            return "Seccess";
        }

        public async Task<string> RemoveAsync(int id)
        {

            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found";
            await _studentRepository.RemoveAsync(student);
            return "Removed successfully";
        }

        public Task<string> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateAsync(int id, string fullname, string group, int average, Education education)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found";

            if (string.IsNullOrWhiteSpace(fullname))
                return "fullname can not be empty";

            if (string.IsNullOrWhiteSpace(group))
                return "group can not be empty";

            if (average < 0 && average > 100)
                return "0-100";


            student.FullName = fullname;
            student.Group = group;
            student.Average = average;
            student.Education = education;
            student.UpdateAt = DateTime.UtcNow.AddHours(4);

            return "updated successfully";
        }
    }
}

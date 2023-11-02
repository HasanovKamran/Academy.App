using Academy.Core.Models;
using Academy.Service.Services.Implementations;
using Academy.Service.Services.Interfaces;
using System;
namespace Academy.Service.Services.Implementations
{
    public class MenuService
    {
        IStudentService studentService = new StudentService();
        public async Task RunApp()
        {
           

            await Menu();
            string request = Console.ReadLine();
            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateStudent();
                        break;
                    case "2":
                        await UpdateStudent();
                        break;
                    case "3":
                        await RemoveStudent();
                        break;
                    case "4":
                        await GetAllStudent();
                        break;
                    case "5":
                        await Get();
                        break;

                    default:
                        break;
                }
                await Menu();
                request = Console.ReadLine();
            }
        }  

        async Task CreateStudent()
{
    Console.WriteLine("add FullName");
    string FullName = Console.ReadLine();
    Console.WriteLine("add Group");
    string Group = Console.ReadLine();
    Console.WriteLine("add Average");
    int.TryParse(Console.ReadLine(), out int Average);
    int i = 1;

    foreach (var item in Enum.GetValues(typeof(Student)))
    {
        Console.WriteLine($"{i} {item}");
        i++;
    }

    bool IsExsist = false;
    int EnumIndex;

    do
    {
        Console.WriteLine("Add Student");
        int.TryParse(Console.ReadLine(), out EnumIndex);
        IsExsist = Enum.IsDefined(typeof(Student), (Student)EnumIndex);
    }
    while (!IsExsist);

    string result = await StudentService.CreateAsync(FullName, Group, Average, (Student)EnumIndex);
    Console.WriteLine(result);
}
        async Task UpdateStudent()
        
        {

            Console.WriteLine("add Id");
            int Id = Console.ReadLine();
            Console.WriteLine("add FullName");
            string FullName = Console.ReadLine();
            Console.WriteLine("add Group");
            string Group = Console.ReadLine();
            Console.WriteLine("add Average");
            int.TryParse(Console.ReadLine(), out int Average);
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(Student)))
            {
                Console.WriteLine($"{i} {item}");
                i++;
            }

            bool IsExsist = false;
            int EnumIndex;

            do
            {
                Console.WriteLine("Add Student");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                IsExsist = Enum.IsDefined(typeof(Student), (Student)EnumIndex);
            }
            while (!IsExsist);

            string result = await StudentService.UpdateAsync(Id,FullName, Group, Average, (Student)EnumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveStudent()
        {
            Console.WriteLine("add Id");
            int Id = Console.ReadLine();
            int result = await studentService.RemoveAsync(Id);
            Console.WriteLine(result);
        }
        async Task GetAllStudent()
        {
            await studentService.GetAllAsync();
        }
        async Task Get()
        {
            Console.WriteLine("add id");
            int id = Console.ReadLine();
            string result=await studentService.GetAsync(id);
            Console.WriteLine(result);
        }
        
           
        
        async Task Menu()
{
    Console.WriteLine("1.Create");
    Console.WriteLine("2.Update");
    Console.WriteLine("3.Remove");
    Console.WriteLine("4.Get");
    Console.WriteLine("5.GetAll");
    Console.WriteLine("0.Close");

}

    }
}

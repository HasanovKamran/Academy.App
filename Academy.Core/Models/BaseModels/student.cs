
using Academy.Core.Enum;
using x =Academy.Core.Models.BaseModel;

namespace Academy.Core.Models
{
    public class Student :x.BaseModel 
    {
        static int _id;
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public int Average { get; set; }
        public Education Education { get; set; }

        public Student(string fullname, string group, int average, Education education)
        {
            _id++;

            string educationName = Education.ToString();
            //Id = $"{Education.ToString()[0]}-{_id}";
            Id = educationName[0];
            FullName = fullname;
            Group = group;
            Average = average;
            Education = education;

        }

        public Student(string fullname, string group, int average, Education education, Education education1) : this(fullname, group, average, education)
        {
            Education = education1;
        }

        public static explicit operator Student(int v)
        {
            throw new NotImplementedException();
        }
    }
}

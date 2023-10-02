using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Student
    {
        protected Student() { }

        public Student(long id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<StudentDiscipline> StudentDisciplines { get; set; }
    }
}
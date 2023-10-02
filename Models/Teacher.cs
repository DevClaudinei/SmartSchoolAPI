using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Teacher
    {
        protected Teacher() { }

        public Teacher(long id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Discipline> Disciplines { get; set; }
    }
}
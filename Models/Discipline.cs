using System.Collections;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Discipline
    {
        protected Discipline() { }

        public Discipline(long id, string name, long teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<StudentDiscipline> StudentDisciplines { get; set; }
    }
}
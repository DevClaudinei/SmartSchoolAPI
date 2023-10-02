namespace SmartSchool.WebAPI.Models
{
    public class StudentDiscipline
    {
        public StudentDiscipline() { }

        public StudentDiscipline(long studentId, long disciplineId) 
        {
            StudentId = studentId;
            DisciplineId = disciplineId;
   
        }
        
        public long Id { get; set; }
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
namespace SmartSchool.WEBAPI.Models
{
    public class Student
    {
        public Student(){}
        public Student(int id, int enroll,
                       string name, string surname, string telephone,
                       DateTime birthDate )
        {
            this.Id = id;
            this.Enroll = enroll;
            this.Name = name;
            this.Surname = surname;
            this.Telephone = telephone;
            this.BirthDate = birthDate;
        }
        public int Id { get; set; }
        public int Enroll { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; } 
        public DateTime BirthDate { get; set; }   
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }    
    }
}
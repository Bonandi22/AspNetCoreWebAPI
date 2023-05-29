namespace SmartSchool.WEBAPI.Models
{
    public class Student
    {
        public Student(){}
        public Student(int id, string name, string surname, string telephone)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Telephone = telephone;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }    
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }    
    }
}
namespace SmartSchool.WEBAPI.Models
{
    public class Teacher
    {
        public Teacher(){}
        public Teacher(int id, int register,
                       string name, string surname)
        {
            this.Id = id;
            this.Register = register;
            this.Surname = surname;
            this.Name = name;            
        }
        public int Id { get; set; }
        public int Register { get; set; }
        public string Name { get; set; }
         public string Surname { get; set; }
        public string Telephone { get; set; }        
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<Subject> Subjects { get; set; }        
    }
}
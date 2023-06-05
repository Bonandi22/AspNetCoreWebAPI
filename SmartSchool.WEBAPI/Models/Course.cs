using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WEBAPI.Models
{
    public class Course
    {
        public Course(){}

        public Course(int id, string name)
        {
            this.Id = id;
            this.Name = name;        
        }
        public int Id { get; set; }
        public  string Name { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }



    }
}
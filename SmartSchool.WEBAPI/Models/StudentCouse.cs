using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WEBAPI.Models
{
    public class StudentCouse
    {
        public  StudentCouse(){}

         public StudentCouse(int studentId, int couseId)
        {
            this.StudentId = studentId;           
            this.CouseId = couseId;         
        }
        
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CouseId { get; set; }
        public Course course { get; set; }

    }
}
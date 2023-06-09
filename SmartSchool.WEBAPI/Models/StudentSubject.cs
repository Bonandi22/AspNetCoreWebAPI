using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WEBAPI.Models
{
    public class StudentSubject
    {
        public StudentSubject(){}
        public StudentSubject(int studentId, int subjectId)
        {
            this.StudentId = studentId;           
            this.SubjectId = subjectId;         
        }
        public int StudentId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public int? Grade { get; set; } = null;
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
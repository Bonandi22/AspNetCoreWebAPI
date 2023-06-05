using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WEBAPI.Models
{
    public class Subject
    {
        public Subject(){}
        public Subject(int id, string name,  int teacherId, int courseId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;
            this.CourseId = courseId;
                      
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int? PreRequisiteId { get; set; } = null;
        public Subject PreRequisite { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }       
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }        
    }
}
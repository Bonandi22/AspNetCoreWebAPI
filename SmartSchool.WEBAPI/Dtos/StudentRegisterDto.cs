using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Dtos
{
    public class StudentRegisterDto
    {
       public int Id { get; set; }
        public int Enroll { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; } 
        public DateTime BirthDate { get; set; }   
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
    }
}
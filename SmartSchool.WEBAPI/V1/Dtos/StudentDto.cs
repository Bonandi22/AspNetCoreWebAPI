using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.V1.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int Enroll { get; set; }
        public string Name { get; set; }     
        public string Telephone { get; set; } 
        public int  Age { get; set; }   
        public DateTime StartDate { get; set; } = DateTime.Now;      
        public bool Active { get; set; } = true;
       
    }
}
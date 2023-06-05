using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WEBAPI.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public int Register { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public bool Active { get; set; } = true;
    }
}
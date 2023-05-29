using Microsoft.AspNetCore.Mvc;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {
        public List<Student> Students = new List<Student>{
            new Student(){
                Id = 1,
                Name = "Marcos",
                Surname = "Almeida",
                Telephone = "465464644"
            },
            new Student() {
                Id = 2,
                Name = "Marta",
                Surname = "Kente",
                Telephone = "789789787"
            },
            new Student() {
                Id = 3,
                Name = "Laura",
                Surname = "Maria",
                Telephone = "456789456"
            },
        }; 
        public StudentController(){}
        
        [HttpGet]
        public IActionResult Get(){
            return Ok(Students);
        }

        // api/student/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int Id){

            var student = Students.FirstOrDefault(a => a.Id == Id);
            if(student == null) return BadRequest("Student not found");
            return Ok(student);
        }
        
        // api/student/name
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {
            var student = Students.FirstOrDefault(a => 
                a.Name.Contains(name) && a.Surname.Contains(surname)
            );
            if (student == null) return BadRequest("Student not found");

            return Ok(student);
        }

        // api/student
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            return Ok(student);
        }

        // api/student
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            return Ok(student);
        }
        // api/student
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
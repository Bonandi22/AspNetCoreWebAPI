using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly DataContext _context;
        public StudentController(DataContext context){
            _context = context;
        }       
        
        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Students);
        }

        // api/student/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int Id){

            var student = _context.Students.FirstOrDefault(a => a.Id == Id);
            if(student == null) return BadRequest("Student not found");
            return Ok(student);
        }
        
        // api/student/name
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {
            var student = _context.Students.FirstOrDefault(a => 
                a.Name.Contains(name) && a.Surname.Contains(surname)
            );
            if (student == null) return BadRequest("Student not found");

            return Ok(student);
        }

         // api/student
        [HttpPost]
        public IActionResult Post(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // api/student
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var people = _context.Students.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(people ==null) return BadRequest("Student not found");
            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // api/student
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var people = _context.Students.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(people ==null) return BadRequest("Student not found");
            _context.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // api/student
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(a => a.Id == id);
            if(student==null) return BadRequest("Student not found");
            _context.Remove(student);
            _context.SaveChanges();
            return Ok();
        }
    }
}
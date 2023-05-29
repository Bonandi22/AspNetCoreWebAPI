using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController:ControllerBase
    {
       private readonly DataContext _context;
        public TeacherController(DataContext context){
            _context = context;
        }       
        
        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Teachers);
        }

        // api/teacher/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int Id){

            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == Id);
            if(teacher == null) return BadRequest("Teacher not found");
            return Ok(teacher);
        }
        
        // api/teacher/name
        [HttpGet("ByName")]
        public IActionResult GetByName(string name)
        {
            var teacher = _context.Teachers.FirstOrDefault(a => 
                a.Name.Contains(name)
            );
            if (teacher == null) return BadRequest("Teacher not found");

            return Ok(teacher);
        }

         // api/teacher
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _context.Add(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // api/teacher
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var people = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if(people ==null) return BadRequest("Teacher not found");
            _context.Update(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // api/teacher
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var people = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if(people ==null) return BadRequest("Student not found");
            _context.Add(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // api/teacher
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(a => a.Id == id);
            if(teacher==null) return BadRequest("Student not found");
            _context.Remove(teacher);
            _context.SaveChanges();
            return Ok();
        }

        
    }
}
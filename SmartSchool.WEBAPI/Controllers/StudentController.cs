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
     
        private readonly IRepository _repo;
        public StudentController( IRepository repo){
            
            _repo = repo;
        }       
        
        [HttpGet]
        public IActionResult Get(){

           var students = _repo.GetAllStudents(true);

           return Ok (students);

        }

        // api/student/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int Id){

            var student = _repo.GetStudentById(Id, false);
            if(student == null) return BadRequest("Student not found");
            return Ok(student);
        }       
        

         // api/student
        [HttpPost]
        public IActionResult Post(Student student)
        {
            _repo.Add(student);

            if(_repo.SaveChanges()){
                return Ok(student);
            }
            return BadRequest("Student not Found");
        }

        // api/student
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var people = _repo.GetStudentById(id);
            if(people ==null) return BadRequest("Student not found");
            _repo.Update(student);
            if(_repo.SaveChanges()){
                return Ok(student);
            }
            return BadRequest("Student not found");
        }

        // api/student
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var people = _repo.GetStudentById(id);
            if(people ==null) return BadRequest("Student not found");
           _repo.Update(student);
            if(_repo.SaveChanges()){
                return Ok(student);
            }
            return BadRequest("Student not found");
        }

        // api/student
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repo.GetStudentById(id);
            if(student==null) return BadRequest("Student not found");
            _repo.Delete(student);
            if(_repo.SaveChanges()){
                return Ok("student Delet");
            }
            return BadRequest("Student not found");
        }
    }
}
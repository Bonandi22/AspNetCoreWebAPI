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
        private readonly IRepository _repo;
        public TeacherController(IRepository repo){
           _repo = repo;
        }           
        
        [HttpGet]
        public IActionResult Get(){
            
            var teacher = _repo.GetAllTeachers(true);

            return Ok();
        }

        // api/teacher/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int Id){

            var teacher = _repo.GetTeacherById(Id, false);
            if(teacher == null) return BadRequest("Teacher not found");
            return Ok(teacher);
        }        
      
         // api/teacher
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _repo.Add(teacher);
            if(_repo.SaveChanges()){
                return Ok(teacher);
            }
            return BadRequest("Teacher not Found");
        }

        // api/teacher
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var people =  _repo.GetTeacherById(id, false);
            if(people ==null) return BadRequest("Teacher not found");
            _repo.Update(teacher);
            if(_repo.SaveChanges()){
                return Ok(teacher);
            }
            return BadRequest("Teacher not found");
        }

        // api/teacher
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var people = _repo.GetTeacherById(id, false);
            if(people ==null) return BadRequest("Teacher not found");
            _repo.Update(teacher);
            if(_repo.SaveChanges()){
                return Ok(teacher);
            }
            return BadRequest("Teacher not found");
        }

        // api/teacher
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if(teacher==null) return BadRequest("Teacher not found");
            _repo.Delete(teacher);
            if(_repo.SaveChanges()){
                return Ok("Teacher Delet");
            }
            return BadRequest("Teacher not found");
        }

        
    }
}
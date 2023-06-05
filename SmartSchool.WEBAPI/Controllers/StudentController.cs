using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Dtos;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {     
        private readonly IRepository _repo;
         private readonly IMapper _mapper;

        public StudentController( IRepository repo, IMapper mapper){
            
            _repo = repo;
            _mapper = mapper;
        }       

        [HttpGet]
        public IActionResult Get(){
           var students = _repo.GetAllStudents(true);          
           return Ok (_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        // api/student/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int Id){

            var student = _repo.GetStudentById(Id, false);
            if(student == null) return BadRequest("Student not found");
            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }       
        

         // api/student
        [HttpPost]
        public IActionResult Post(StudentRegisterDto model)
        {
            var student = _mapper.Map<Student>(model);
            _repo.Add(student);
            if(_repo.SaveChanges()){
                return Created($"/api/student/{model.Id}", 
                                _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Student not Found");
        }

        // api/student
        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id);
            if(student ==null) return BadRequest("Student not found");

            _mapper.Map(model, student);
            
            _repo.Update(student);
            if(_repo.SaveChanges()){
                return Created($"/api/student/{model.Id}", 
                                _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Student not found");
        }

        // api/student
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id);
            if(student ==null) return BadRequest("Student not found");

             _mapper.Map(model, student);

           _repo.Update(student);
            if(_repo.SaveChanges()){
                return Created($"/api/student/{model.Id}", 
                                _mapper.Map<StudentDto>(student));
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
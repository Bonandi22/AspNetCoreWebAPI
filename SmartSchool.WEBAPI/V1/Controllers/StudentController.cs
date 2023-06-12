using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;
using SmartSchool.WEBAPI.V1.Dtos;
using SmartSchool.WEBAPI.Helpers;

namespace SmartSchool.WEBAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController: ControllerBase
    {     
        private readonly IRepository _repo;
         private readonly IMapper _mapper;

        public StudentController( IRepository repo, IMapper mapper){
            
            _repo = repo;
            _mapper = mapper;
        }       
         /// <summary>
        /// Método responsável para retornar todos os meus alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams){
            
          var student = await _repo.GetAllStudentsAsync(pageParams, true);

            var studentResult = _mapper.Map<IEnumerable<StudentDto>>(student);

            Response.AddPagination(student.CurrentPage, student.PageSize, student.TotalCount, student.TotalPages);

            return Ok(studentResult);
        }

        // api/student/byId
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){

            var student = await _repo.GetStudentById(id, false);
            if (student == null)
                return BadRequest("Student not found");
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
                return Created($"/api/Student/{model.Id}", 
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
                return Created($"/api/Student/{model.Id}", 
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
                return Created($"/api/Student/{model.Id}", 
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
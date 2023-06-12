using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;
using SmartSchool.WEBAPI.V1.Dtos;

namespace SmartSchool.WEBAPI.V1.ControllersControllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _repo;
         private readonly IMapper _mapper;
        public TeacherController( IRepository repo, IMapper mapper){
            
            _repo = repo;
            _mapper = mapper;
        }             
        
        [HttpGet]
        public IActionResult Get(){
            
            var teacher = _repo.GetAllTeachers(true);
            return Ok (_mapper.Map<IEnumerable<TeacherDto>>(teacher));
        }

        // api/teacher/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int Id){

            var teacher = _repo.GetTeacherById(Id, false);
            if(teacher == null) return BadRequest("Teacher not found");
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            return Ok(teacher);
        }        
      
         // api/teacher
        [HttpPost]
        public IActionResult Post(TeacherDto model)
        {
            var teacher = _mapper.Map<Teacher>(model);
            _repo.Add(teacher);
            if(_repo.SaveChanges()){
                return Created($"/api/Teacher/{model.Id}", 
                                _mapper.Map<TeacherDto>(teacher));
            }
            return BadRequest("Teacher not Found");
        }

        // api/teacher
        [HttpPut("{id}")]
        public IActionResult Put(int id, TeacherDto model)
        {
            var teacher =  _repo.GetTeacherById(id, false);
            if(teacher ==null) return BadRequest("Teacher not found");
            _mapper.Map(model, teacher);
            _repo.Update(teacher);
            if(_repo.SaveChanges()){
                return Created($"/api/Teacher/{model.Id}", 
                                _mapper.Map<TeacherDto>(teacher));
            }
            return BadRequest("Teacher not found");
        }

        // api/teacher
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, TeacherDto model)
        {
            var teacher =  _repo.GetTeacherById(id, false);
            if(teacher ==null) return BadRequest("Teacher not found");
            _mapper.Map(model, teacher);
            _repo.Update(teacher);
            if(_repo.SaveChanges()){
                return Created($"/api/Teacher/{model.Id}", 
                                _mapper.Map<TeacherDto>(teacher));
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
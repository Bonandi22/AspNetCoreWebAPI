using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;
using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.V1.Dtos;

namespace SmartSchool.WEBAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _repo;
         private readonly IMapper _mapper;
        public TeacherController( IRepository repo, IMapper mapper){
            
            _repo = repo;
            _mapper = mapper;
        }             
        // api/teacher
        [HttpGet]
       public async Task<IActionResult> Get([FromQuery] PageParams pageParams){
            
          var teacher = await _repo.GetAllTeachersAsync(pageParams, true);

          var teacherResult = _mapper.Map<IEnumerable<TeacherDto>>(teacher);

          Response.AddPagination(teacher.CurrentPage, teacher.PageSize, teacher.TotalCount, teacher.TotalPages);

          return Ok(teacherResult);
        }

        // api/teacher/byId
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            
            var teacher = await _repo.GetTeacherByIdAsync(id, false);
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
        public async Task<IActionResult> Put(int id, TeacherDto model)
        {
            var teacher = await _repo.GetTeacherByIdAsync(id, false);
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
        public  async Task<IActionResult>  Patch(int id, TeacherDto model)
        {
            var teacher = await _repo.GetTeacherByIdAsync(id, false);
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
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _repo.GetTeacherByIdAsync(id, false);
            if(teacher==null) return BadRequest("Teacher not found");
             _repo.Delete(teacher);
            if(_repo.SaveChanges()){
                return Ok("Teacher Delet");
            }
            return BadRequest("Teacher not found");
        }        
    }
}
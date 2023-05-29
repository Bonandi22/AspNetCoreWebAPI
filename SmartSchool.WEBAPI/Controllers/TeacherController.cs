using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController:ControllerBase
    {
         public TeacherController(){}        
        [HttpGet]
        public IActionResult Get(){
            return Ok();
        }

        
    }
}
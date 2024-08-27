using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My1stWebAPIProject.Modules;


namespace My1stWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("api/IDOrder/{id}")]

        public IActionResult GetID(int id)
        {
            return Ok($"{id}");
        }

        [HttpPost("api/UsingQueryString")]

        public IActionResult CreateEE(string? F_Name,string? L_Name, int? Roll_No)
        {
            return Ok($"{F_Name} \t{L_Name}\t{Roll_No}\t");
        }

        [HttpPost("api/UsingFromBody")]

        public IActionResult CreateEE([FromBody] GetStudent s)
        {
            return Ok($"{s.First_Name} \t {s.Last_Name} \t {s.StudentID}");
        }

        [HttpGet]
        public IActionResult UsingFromURI([System.Web.Http.FromUri] int EID)
        {
            return Ok($"{EID}");
        }
    }
}

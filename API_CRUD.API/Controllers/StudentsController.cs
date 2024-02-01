using API_CRUD.BL.DTO;
using API_CRUD.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepo;

        public StudentsController(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            return Ok(await studentRepo.GetAllStudent());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student with id: "+id+" is not found");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]StudentDTO model)
        {
            if(model.Name== "string")
            {
                return BadRequest("Student name = 'string' is not allowed");
            }
            await studentRepo.AddStudent(model);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO model)
        {
            var student = await studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student with id: " + id + " is not found");
            }
            if (model.Name== "string")
            {
                return BadRequest("Student name = 'string' is not allowed");
            }
            await studentRepo.UpdateStudent(id, model);
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentint (int id)
        {
            var student = await studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student with id: " + id + " is not found");
            }
            await studentRepo.DeleteStudent(id);
            return Ok("Succesfully Removed Student with id " + id);
        }
    }
}

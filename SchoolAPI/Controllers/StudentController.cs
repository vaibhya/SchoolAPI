using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using SchoolAPI.Model;
using SchoolAPI.ModelDTO;
using SchoolAPI.Service;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("School")]

    public class StudentController : Controller
    {
        private IStudentService _service;
        public StudentController(IStudentService service) 
        {
            _service = service;

        }

        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetAllStudents(string? firstName, string? lastName, string? email, int? page=1, int? limit = 10)
        {
            var students = _service.GetAllStudents(firstName,lastName,email,page,limit);
            return Ok(students);
        }

        [HttpGet]
        [Route("GetStudent/{id}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(_service.GetStudentById(id));
        }

        [HttpPost]
        [Route("PostStudent")]
        public IActionResult CreateStudent(StudentCreateDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(_service.AddStudent(studentDto));
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(StudentUpdateDTO studentDto)
        {
            return Ok(_service.UpdateStudent(studentDto));
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var response = _service.DeleteStudent(id);
            if(response == 0)
            {
                return NotFound();
            }
            return Ok("Student deleted successfully.");
        }
    }
}

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Created("Id: ", student.Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_context.Students.FirstOrDefault(x => x.Id.Equals(id)));
        }

        [HttpPut]
        public IActionResult Update(long id, Student student)
        {
            var studentFound = _context.Students.FirstOrDefault(x => x.Id.Equals(id));

            if (studentFound is null) 
                return NotFound($"Student for Id: {id} could not be found.");

            studentFound.Id = id;
            studentFound.FirstName = student.FirstName;
            studentFound.LastName = student.LastName;
            studentFound.Email = student.Email;

            _context.Update(studentFound);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id.Equals(id));

            if (student is null) 
                return NotFound($"Student for Id: {id} could not be found.");
            
            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
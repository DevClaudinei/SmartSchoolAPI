using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
      private readonly DataContext _context;

        public TeachersController(DataContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return Created("Id: ", teacher.Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Teachers);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_context.Teachers.FirstOrDefault(x => x.Id.Equals(id)));
        }

        [HttpPut]
        public IActionResult Update(long id, Teacher teacher)
        {
            var teacherFound = _context.Teachers.FirstOrDefault(x => x.Id.Equals(id));
            
            if (teacherFound is null) 
                return NotFound($"Teacher for Id: {id} could not be found.");

            teacherFound.Id = id;
            teacherFound.FirstName = teacher.FirstName;
            teacherFound.LastName = teacher.LastName;

            _context.Update(teacherFound);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id.Equals(id));
            
            if (teacher is null) 
                return NotFound($"Teacher for Id: {id} could not be found.");
            
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
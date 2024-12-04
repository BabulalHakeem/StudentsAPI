using Microsoft.AspNetCore.Mvc;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentsController:Controller
    { 
        private readonly StdDbontext _db;
        public StudentsController(StdDbontext db)
        {
            _db = db;

        }
        [HttpPost]
        public ActionResult<Students> Create([FromBody]Students student)
        {
            bool bol= _db.students.AsQueryable().Where(x => x.Name.Trim().ToLower() == student.Name.Trim().ToLower()).Any();
            if (bol)
            {
                return BadRequest();
            }
            _db.students.Add(student);
            _db.SaveChanges();
            return Ok();

        }
        [HttpGet]
        public ActionResult<IEnumerable<Students>> GetAll()
        {
            return _db.students.ToList();
        }
        [HttpGet("{id:int}")]
        public ActionResult<Students> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            return _db.students.Find(id);
        }
        [HttpPut]
        public ActionResult<Students> Update([FromBody]Students student)
        {
            _db.students.Update(student);
            _db.SaveChanges();
            return Ok(student);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var std = _db.students.Find(id);
            _db.students.Remove(std);
            _db.SaveChanges();
            return Ok();
        }





    }
}

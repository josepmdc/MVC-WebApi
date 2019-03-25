using Dao;
using Dao.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Mapping;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class StudentController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Create(StudentDto student)
        {
            Mapper mapper = new Mapper();
            Student studentDataObject = mapper.StudentDtoToDao(student);
            StudentRepository repo = new StudentRepository();
            repo.Create(studentDataObject);
            return Ok();
        }
        
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            StudentRepository repo = new StudentRepository();
            List<Student> students = repo.ReadAll();
            return Json(students);
        }

        [HttpGet]
        public IHttpActionResult ReadById(int id)
        {
            StudentRepository repo = new StudentRepository();
            Student student = repo.ReadById(id);
            return Json(student);
        }
    }
}

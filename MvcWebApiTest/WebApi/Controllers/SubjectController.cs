using Dao;
using Dao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class SubjectController : ApiController
    {

        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            SubjectRepository repo = new SubjectRepository();
            List<Subject> subjects = repo.ReadAll();
            return Json(subjects);
        }
    }
}
using SchoolManagerWebClient.Models;
using SchoolManagerWebClient.Repositories;
using SchoolManagerWebClient.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagerWebClient.Controllers
{
    public class StudentController : Controller
    {
        IRepository<StudentViewModel> StudentRepository;
        IRepository<SubjectViewModel> SubjectRepository;

        public StudentController()
        {
            StudentRepository = new StudentRepository();
            SubjectRepository = new SubjectRepository();
        }

        public StudentController(IRepository<StudentViewModel> studentRepository, IRepository<SubjectViewModel> subjectRepository)
        {
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<StudentViewModel> students = StudentRepository.ReadAll();

            return View(students);
        }

        public ActionResult Details(int id)
        {
            StudentViewModel student = StudentRepository.ReadById(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            List<SubjectViewModel> subjects = SubjectRepository.ReadAll();
            return View(subjects);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                StudentViewModel student = new StudentViewModel 
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"]
                };

                var response = StudentRepository.Create(student);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            StudentViewModel student = StudentRepository.ReadById(id);
            return View(student);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                StudentViewModel student = new StudentViewModel {
                    Id = id,
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"]
                };
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

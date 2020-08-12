using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;
using SchoolWeb.Models;
using SchoolWeb.Contracts;

namespace SchoolWeb.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: Student
        public ActionResult Index()
        {
            var StudentListing = _repo.FindAll().ToList();
            var Model = _mapper.Map<List<Student>, List<StudentVM>>(StudentListing);
            return View(Model);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Students = _repo.FindById(id);
            var Model = _mapper.Map<StudentVM>(Students);

            return View(Model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM Data)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(Data);
                }

                var Students = _mapper.Map<Student>(Data);
                Students.DateCreated = DateTime.Now;
                var Successful = _repo.Create(Students);

                if (!Successful)
                {
                    ModelState.AddModelError("", "There was an unknown error. database was not updated.");
                    return View(Data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "There was an unknown error. database was not updated.");
                return View(Data);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Students = _repo.FindById(id);
            var Model = _mapper.Map<StudentVM>(Students);

            return View(Model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
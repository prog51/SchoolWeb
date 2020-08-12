using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Contracts;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _repo;
        private readonly IMapper _mapper;

        public SchoolController(ISchoolRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: School
        public ActionResult Index()
        {
            var SchoolListing = _repo.FindAll().ToList();
            var Model = _mapper.Map<List<School>, List<SchoolVM>>(SchoolListing);
            return View(Model);
        }

        // GET: School/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Schools = _repo.FindById(id);
            var Model = _mapper.Map<SchoolVM>(Schools);
            return View(Model);
        }

        // GET: School/Create
        public ActionResult Create()
        {
            return View(); //view already created
        }

        // POST: School/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSchoolVM Data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Data);
                }

                var Schools = _mapper.Map<School>(Data);
                Schools.DateCreated = DateTime.Now;
                var Successful = _repo.Create(Schools);

                if (!Successful)
                {
                    ModelState.AddModelError("","There was an unknown error. database was not updated.");
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

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Schools = _repo.FindById(id);
            var Model = _mapper.Map<SchoolVM>(Schools);

            return View(Model);
        }

        // POST: School/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SchoolVM Data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Data);
                }

                var Schools = _mapper.Map<School>(Data);
                var Successful = _repo.Update(Schools);

                if (!Successful)
                {
                    ModelState.AddModelError("", "There was an unknown error. database was not updated.");
                    return View(Data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Delete/5
        public ActionResult Delete(int id)
        {
            var School = _repo.FindById(id);

            if (School == null)
            {
                return NotFound();
            }
            var Successful = _repo.Delete(School);

            if (!Successful)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: School/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SchoolVM Data)
        {
            try
            {
                // TODO: Add delete logic here
                var School = _repo.FindById(id);

                if (School == null)
                {
                    return NotFound();
                }
                var Successful = _repo.Delete(School);

                if (!Successful)
                {
                    return View(Data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
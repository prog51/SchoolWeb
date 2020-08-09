using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Contracts;

namespace SchoolWeb.Controllers
{
    public class PlacementController : Controller
    {

        private readonly IPlacementRepository _repo;
        private readonly IMapper _mapper;

        public PlacementController(IPlacementRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        // GET: Placement
        public ActionResult Index()
        {
            return View();
        }

        // GET: Placement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Placement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Placement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Placement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Placement/Edit/5
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

        // GET: Placement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Placement/Delete/5
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
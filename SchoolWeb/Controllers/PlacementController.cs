using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWeb.Contracts;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class PlacementController : Controller
    {

        private readonly IPlacementRepository _repo;
        private readonly ISchoolRepository _repoSch;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _repostu;
        private readonly UserManager<IdentityUser> _UserManager;

        public PlacementController(
            IPlacementRepository repo,
            IMapper mapper,
             UserManager<IdentityUser> UserManager,
             ISchoolRepository repoSch,
             IStudentRepository repostu
           )
        {
            _repo = repo;
            _mapper = mapper;
            _UserManager = UserManager;
            _repoSch = repoSch;
            _repostu = repostu;
        }


        // GET: Placement
        public ActionResult Index()
        {
            var placementL = _repo.FindAll().ToList();
            var Model = _mapper.Map<List<Placement>, List<PlacementVM>>(placementL);
            return View(Model);
        }

        // GET: Placement/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Placements = _repo.FindById(id);
            var Model = _mapper.Map<PlacementVM>(Placements);

            return View(Model);
        }

        // GET: Placement/Create
        public ActionResult Create()
        {
            var Schools = _repoSch.FindAll();
            var Students = _repostu.FindAll();
            var user = _UserManager.GetUserAsync(User).Result;

            var model1 = Schools.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model2= Students.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var Data = new CreatePlacementVM
            {
                //Schools = model1,
                OrganizationID = user.Id

            };
            return View(Data);
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
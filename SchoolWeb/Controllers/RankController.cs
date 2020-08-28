using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWeb.Contracts;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    [Authorize(Roles = "ExamBody")]
    public class RankController : Controller
    {

        private readonly IRankRepository _repo;
        private readonly ISchoolRepository _repoSch;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _UserManager;
        // GET: Rank


        public RankController(IRankRepository repo, 
            IMapper mapper,
            ISchoolRepository repoSch,
             UserManager<IdentityUser> UserManager
          )
        {
            _repo = repo;
            _mapper = mapper;
            _repoSch = repoSch;
            _UserManager = UserManager;
        }

        public ActionResult Index()
        {
            var RankListing = _repo.FindAll().ToList();
            var Model = _mapper.Map<List<Rank>,List<RankVM>>(RankListing);
            return View(Model);
        }

        // GET: Rank/Details/5
        public ActionResult Details(int id)
        {
             if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Data = _repo.FindById(id);
            var Model = _mapper.Map<RankVM>(Data);
            return View(Model);
        }

        // GET: Rank/Create
        public ActionResult Create()
        {
        
             return View();
        }

        // POST: Rank/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRankVM Data)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(Data);
                }
                var org = _UserManager.GetUserAsync(User).Result;

                var Ranks = _mapper.Map<Rank>(Data);
                
                Ranks.DateCreated = DateTime.Now;
                Ranks.OrganizationID = org.Id;
                var Successful = _repo.Create(Ranks);

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

        // GET: Rank/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Ranks = _repo.FindById(id);
            var Model = _mapper.Map<RankVM>(Ranks);

            return View(Model);
        }

        // POST: Rank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RankVM Data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Data);
                }

                var Ranks = _mapper.Map<Rank>(Data);
                var Successful = _repo.Update(Ranks);

                if (Successful)
                {
                    ModelState.AddModelError("", "Record was updated");
                    return View(Data);
                }

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

        // GET: Rank/Delete/5
        public ActionResult Delete(int id)
        {
            var remove = _repo.FindById(id);

            if (remove == null)
            {
                return NotFound();
            }
            var Successful = _repo.Delete(remove);

            if (!Successful)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
            
        }

        // POST: Rank/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RankVM Data)
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
﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWeb.Contracts;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolWeb.Controllers
{

    [Authorize(Roles = "ExamBody")]
    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _repo;
        private readonly IMapper _mapper;
        private readonly IRankRepository _repoRank;
        private readonly UserManager<IdentityUser> _UserManager;

        public SchoolController(
            ISchoolRepository repo, 
            IMapper mapper, 
            IRankRepository repoRank,
            UserManager<IdentityUser> UserManager
            )
        {
            _repo = repo;
            _mapper = mapper;
            _repoRank = repoRank;
            _UserManager = UserManager;
        }

        // GET: School
        public ActionResult Index()
        {
            var SchoolListing = _repo.FindAll();
            var Model = _mapper.Map<List<SchoolVM>>(SchoolListing);

            var Model2 = new DisplaySchoolVM
            {
                Rank = Model
            };


            return View(Model2);
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
         
            var RankVals = _repoRank.FindAll();
            var Ran = RankVals.Select(q => new SelectListItem
            {
                Text = q.ValueRank,
                Value = q.Id.ToString()
            });
            var model = new CreateSchoolVM
            {
                Ranks = Ran

            };
            return View(model);
           
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
                var org = _UserManager.GetUserAsync(User).Result;
                var currentLoginID = org.Id;
                var Schools = _mapper.Map<School>(Data);
                Schools.DateCreated = DateTime.Now;
                Schools.OrganizationID = org.Id;
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

            /*var countReturnReturn = _repo.FindAll();

            var schoolRecord = _mapper.Map<School>(countReturnReturn);*/
            

           
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var Schools = _repo.FindById(id);
            var Model = _mapper.Map<EditSchoolVM>(Schools);

            return View(Model);
        }

        // POST: School/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSchoolVM Data)
        {
             try
              {
                if (!ModelState.IsValid)
                {
                    foreach (var modelError in ModelState)
                    {
                        string propertyName = modelError.Key;
                        if (modelError.Value.Errors.Count > 0)
                        {
                            ModelState.AddModelError("", propertyName +": " +  modelError.Value.ToString());
                        }
                    }
                    return View(Data);
                }

                var Schools = _mapper.Map<School>(Data);
                var Successful = _repo.Update(Schools);

                if (Successful)
                {
                    ModelState.AddModelError("", "Database was not updated.");
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
                ModelState.AddModelError("", "There was an unknown error. database was not updated.");
                return View(Data);
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
                return View(Data);
            }
        }
    }
}
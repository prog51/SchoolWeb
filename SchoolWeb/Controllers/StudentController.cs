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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SchoolWeb.Repository;

namespace SchoolWeb.Controllers
{
    [Authorize(Roles = "ExamBody")]
    public class StudentController : Controller
    {

        private readonly IStudentRepository _repo;
        private readonly IPlacementRepository _repoPla; 
        private readonly IMapper _mapper;
        private readonly ISchoolRepository _repoSch;
        private readonly UserManager<IdentityUser> _UserManager;

        public StudentController(
            IStudentRepository repo, 
            IMapper mapper, 
            UserManager<IdentityUser> UserManager, 
            IPlacementRepository repoPla,
            ISchoolRepository repoSch
            )
        {
            _repo = repo;
            _mapper = mapper;
            _UserManager = UserManager;
            _repoPla = repoPla;
            _repoSch = repoSch;

        }

        // GET: Student
        public ActionResult Index()
        {
            var org = _UserManager.GetUserAsync(User).Result;
            var currentLoginID = org.Id;
            var StudentListing = _repo.FindAll().Where(q => q.OrganizationID == currentLoginID).ToList();
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

        public ActionResult CheckForSchools(int id)
        {
            var org = _UserManager.GetUserAsync(User).Result;
            var check = _repo.FindSchools(id).ToList();
            var data = _repo.FindById(id);



            var MatchedSchools = _repo.FindSchools(id);
            var i = 0;
            var SchoolArray = MatchedSchools.ToArray();
            var count = SchoolArray.Count();


            while (i < count)
            {

                var placementModel = new PlacementVM
                {
                    OrganID = org.Id,
                    StudentID = data.Id,
                    SchoolID = SchoolArray[i].Id,
                    DateCreated = DateTime.Now
                };

                var NewplacementRecords = _mapper.Map<Placement>(placementModel);

                var Success2 = _repoPla.Create(NewplacementRecords);

                if (Success2)
                {
                    ModelState.AddModelError("", "placed.");
                    return RedirectToAction(nameof(Index));
                }
                else if (!Success2)
                {
                    ModelState.AddModelError("", "Not placed.");
                    return RedirectToAction(nameof(Index));
                }
                i++;
            }



            return RedirectToAction(nameof(Index));
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM Data)
        {
            var org = _UserManager.GetUserAsync(User).Result;
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(Data);
                }

                var Students = _mapper.Map<Student>(Data);
                Students.DateCreated = DateTime.Now;
                Students.OrganizationID = org.Id;
                var Successful = _repo.Create(Students);


                var MatchedSchools = _repo.FindSchools(Students.Id);

                var i = 0;
                var SchoolArray = MatchedSchools.ToArray();
                var count = SchoolArray.Count();


             while (i < count)
                {
                    var placementModel = new PlacementVM
                    {
                     OrganID = org.Id,
                     StudentID = Students.Id,
                     SchoolID = SchoolArray[i].Id,
                     DateCreated = DateTime.Now
                    };                    
                    
                    var NewplacementRecords = _mapper.Map<Placement>(placementModel);

                    var Success2 = _repoPla.Create(NewplacementRecords);

                    if (Success2)
                    {
                        ModelState.AddModelError("", "placed.");
                        return View(Data);
                    }
                    else if(!Success2)
                    {
                        ModelState.AddModelError("", "Not placed.");
                        return View(Data);
                    }
                    i++;
                }               

                if (!Successful)
                {
                    ModelState.AddModelError("", "There was an unknown error. database was not updated.iojoo");
                    return RedirectToAction(nameof(Index));
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
        public ActionResult Edit(StudentVM Data)
        {
            try
            {
                // TODO: Add update logic here

                if (!ModelState.IsValid)
                {
                    return View(Data);
                }

                var Students = _mapper.Map<Student>(Data);
                var Successful = _repo.Update(Students);

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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {

            var Student = _repo.FindById(id);

            if (Student == null)
            {
                return NotFound();
            }
            var Successful = _repo.Delete(Student);

            if (!Successful)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
           
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StudentVM Data)
        {
            try
            {
                // TODO: Add delete logic here
                var Student = _repo.FindById(id);

                if (Student == null)
                {
                    return NotFound();
                }
                var Successful = _repo.Delete(Student);

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
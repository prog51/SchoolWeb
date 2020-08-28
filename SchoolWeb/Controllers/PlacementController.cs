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
    public class PlacementController : Controller
    {

        private readonly IPlacementRepository _repo;
        private readonly ISchoolRepository _repoSch;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _repostu;
        private readonly IMailService _mailService;
        private readonly UserManager<IdentityUser> _UserManager;

        public PlacementController(
            IPlacementRepository repo,
            IMapper mapper,
             UserManager<IdentityUser> UserManager,
             ISchoolRepository repoSch,
             IStudentRepository repostu,
             IMailService mailService
           )
        {
            _repo = repo;
            _mapper = mapper;
            _UserManager = UserManager;
            _repoSch = repoSch;
            _repostu = repostu;
            _mailService = mailService;
        }


        // GET: Placement
        public ActionResult Index()
        {
            var placementL = _repo.FindAll();
            var Model = _mapper.Map<List<PlacementVM>>(placementL);

           var Data = new DisplayPlacementVM
            {
                 placement = Model
            };

            return View(Data);
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


        public ActionResult PlacementAction(int id)
        {

            var PlaceData = _repo.FindById(id);

            var schoolId = PlaceData.SchoolID;
            var studentId = PlaceData.StudentID;


            var Student = _repostu.FindById(studentId);
            var school = _repoSch.FindById(schoolId);
            var SchoolName = school.Name;

            Student.Placed = SchoolName;

           var Success = _repostu.Update(Student);

            if(Success)
            {
                 var mail = new MailRequest
                    {
                        Body = "Hi, Student.",
                        Subject = "Student",
                        ToEmail = Student.Email
                 };
                
                _mailService.SendEmail(mail);

                var mail2 = new MailRequest
                {
                    Body = "Hi, School.",
                    Subject = "School",
                    ToEmail = school.Email
                };
                _mailService.SendEmail(mail2);
            }

            return View();
        }
        // GET: Placement/Create
        public ActionResult Create()
        {

            var Schools = _repoSch.FindAll();
            var Students = _repostu.FindAll();

            var SchoolModel = Schools.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var StudentModel = Students.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model = new CreatePlacementVM
            {
                School = SchoolModel,
                Student = StudentModel
            };

            return View(model);

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
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var place = _repo.FindById(id);
            var Model = _mapper.Map<DisplayPlacementVM>(place);
            return View(Model);
        }

        public ActionResult PlaceStudent(int Stuid, string schoolName)
        {

            return View();
        }

        // POST: Placement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DisplayPlacementVM Data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Data);
                }

                var place = _mapper.Map<Placement>(Data);
                var Successful = _repo.Update(place);

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
                ModelState.AddModelError("", "There was an unknown error. database was not updated.");
                return View(Data);
            }
        }

        // GET: Placement/Delete/5
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
using FakeBK.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeBK.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Student> objStudentList = _db.Students.ToList();
            return View(objStudentList);
        }

        public IActionResult Create()
        {
            ViewBag.Classes = _db.Classes.ToList(); // Dropdown for Class
            ViewBag.OrgPeople = _db.Orgpeople.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classes = _db.Classes.ToList();
            ViewBag.OrgPeople = _db.Orgpeople.ToList();
            return View(obj);
            //return View();
        }

        public IActionResult Edit(decimal? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            Student? stuFronDB = _db.Students.Find(Id);
            if(stuFronDB == null)
            {
                return NotFound();
            }
            return View(stuFronDB);
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Delete(decimal? Id)
        //{
        //    if (Id == null || Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Student? stuFronDB = _db.Students.Find(Id);
        //    if (stuFronDB == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(stuFronDB);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(decimal? Id)
        //{

        //    Student? obj = _db.Students.Find(Id);

        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Students.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");

        //}

        public IActionResult Find(decimal? Id)
        {
            if (Id == null || Id == 0)
            {
                ViewBag.Message = "Invalid Student ID.";
                return View(); // Return a search view with a message
            }

            // Find student by ID
            Student? student = _db.Students.FirstOrDefault(s => s.Id == Id);

            if (student == null)
            {
                ViewBag.Message = "Student not found.";
                return View(); // Return a search view with a message
            }

            // Return the student details to the view
            return View(student);
        }

        public IActionResult Delete(decimal? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            // Find the student by ID
            Student? student = _db.Students.Find(Id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Handle the deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(decimal? Id)
        {
            // Find the student by ID
            Student? student = _db.Students.Find(Id);
            if (student == null)
            {
                return NotFound();
            }

            // Remove the student from the database
            _db.Students.Remove(student);
            _db.SaveChanges();

            // Redirect to the Index page after deletion
            return RedirectToAction("Index");
        }


    }
}

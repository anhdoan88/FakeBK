using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FakeBK.Models;

namespace FakeBK.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teacher
        public IActionResult Index()
        {
            List<Teacher> objTeacherList = _context.Teachers.ToList();
            return View(objTeacherList);
        }

        // GET: Teacher/Details/5
        //public async Task<IActionResult> Details(decimal? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var teacher = await _context.Teachers
        //        .Include(t => t.Dept)
        //        .Include(t => t.Orgp)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (teacher == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teacher);
        //}

        // GET: Teacher/Create
        //public IActionResult Create()
        //{
        //    ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id");
        //    ViewData["OrgpId"] = new SelectList(_context.Orgpeople, "Id", "Id");
        //    return View();
        //}

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,OrgpId,DeptId")] Teacher teacher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(teacher);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", teacher.DeptId);
        //    ViewData["OrgpId"] = new SelectList(_context.Orgpeople, "Id", "Id", teacher.OrgpId);
        //    return View(teacher);
        //}

        // GET: Teacher/Edit/5
        //public async Task<IActionResult> Edit(decimal? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var teacher = await _context.Teachers.FindAsync(id);
        //    if (teacher == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", teacher.DeptId);
        //    ViewData["OrgpId"] = new SelectList(_context.Orgpeople, "Id", "Id", teacher.OrgpId);
        //    return View(teacher);
        //}

        //POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public IActionResult Edit(decimal? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Teacher? teaFronDB = _context.Teachers.Find(Id);
            if (teaFronDB == null)
            {
                return NotFound();
            }
            return View(teaFronDB);
        }
        [HttpPost]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Teacher/Delete/5
        //public async Task<IActionResult> Delete(decimal? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var teacher = await _context.Teachers
        //        .Include(t => t.Dept)
        //        .Include(t => t.Orgp)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (teacher == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teacher);
        //}

        // POST: Teacher/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(decimal id)
        //{
        //    var teacher = await _context.Teachers.FindAsync(id);
        //    if (teacher != null)
        //    {
        //        _context.Teachers.Remove(teacher);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TeacherExists(decimal id)
        //{
        //    return _context.Teachers.Any(e => e.Id == id);
        //}

        public IActionResult Create()
        {
            // Optional: Load dropdown data for related entities
            ViewBag.Departments = _context.Departments.ToList(); // Dropdown for departments
            ViewBag.Orgperson = _context.Orgpeople.ToList(); // Dropdown for orgperson
            return View();
        }

        // POST: Handle form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                // Add the new teacher to the database
                _context.Teachers.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Reload dropdown data in case of validation failure
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.OrgPeople = _context.Orgpeople.ToList();
            return View(obj);
        }

        public IActionResult Find(decimal? Id)
        {
            if (Id == null || Id == 0)
            {
                ViewBag.Message = "Invalid Teacher ID.";
                return View(); // Return a search view with a message
            }

            // Find student by ID
            var teacher = _context.Teachers.FirstOrDefault(s => s.Id == Id);

            if (teacher == null)
            {
                ViewBag.Message = "Teacher not found.";
                return View(); // Return a search view with a message
            }

            // Return the student details to the view
            return View(teacher);
        }
    }
}

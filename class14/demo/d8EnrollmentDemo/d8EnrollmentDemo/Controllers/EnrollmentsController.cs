using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using d8EnrollmentDemo.Data;
using d8EnrollmentDemo.Models;

namespace d8EnrollmentDemo.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly EnrollmentDbContext _context;

        public EnrollmentsController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var enrollmentDbContext = _context.CourseEnrollments.Include(e => e.Course).Include(e => e.Student);
            return View(await enrollmentDbContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.CourseEnrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "CourseCode");
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,StudentID")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "ID", enrollments.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", enrollments.StudentID);
            return View(enrollments);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? courseID, int? studentID)
        {
            if (courseID == null || studentID == null)
            {
                return NotFound();
            }

            var enrollments = await _context.CourseEnrollments.FirstOrDefaultAsync(x => x.StudentID == studentID && x.CourseID == courseID);
            if (enrollments == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "CourseCode", enrollments.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FullName", enrollments.StudentID);
            return View(enrollments);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,StudentID")] Enrollments enrollments)
        {
            if (id != enrollments.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentsExists(enrollments.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "ID", enrollments.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", enrollments.StudentID);
            return View(enrollments);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.CourseEnrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollments = await _context.CourseEnrollments.FindAsync(id);
            _context.CourseEnrollments.Remove(enrollments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentsExists(int id)
        {
            return _context.CourseEnrollments.Any(e => e.StudentID == id);
        }
    }
}

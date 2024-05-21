using ASP_NET_Core_MVC_Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_MVC_Academy.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AcademyContext _context;

        public StudentsController(AcademyContext context)
        {
            _context = context;
        }
        //=============================================================
        // GET: Student/Index
        public async Task<IActionResult> Index()
        {
            var academyContext = _context.Students.Include(s => s.Group);
            return View(await _context.Students.ToListAsync());
        }
        //=============================================================
        // GET: Student/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students==null)
            {
                return NotFound();
            }
            
            var student = await _context.Students.Include(s=>s.Group).FirstOrDefaultAsync(m=>m.Id==id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        //=============================================================
        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }
		
		// POST: Student/Create
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,EMail,GroupId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", student.GroupId);
            return View(student);

            //try
            //{
            //    _context.Add(students);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //catch (Exception)
            //{

            //    return RedirectToAction(nameof(Index));
            //}
        }
        //=============================================================
        // GET: Student/Edit
        public async Task<IActionResult>Edit(int? id)
        {
            if (id==null || _context.Students==null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            //ViewBag.GroupId = new SelectList(_context.Groups, "Id", "Name", students.GroupId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", student.GroupId);
            return View(student);
        }

        // POST: Student/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,EMail,GroupId")] Student student)
        {
            if (id!=student.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
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
        //=============================================================
        // GET: Student/Delete
        public async Task <IActionResult> Delete(int? id)
        {
            if (id==null || _context.Students==null)
            {
                return NotFound();
            }

            var student=await _context.Students.Include(s=>s.Group).FirstOrDefaultAsync(m=>m.Id==id);

            if (student==null)
            {
                return NotFound();
            }

            return View(student);
        }        	

		// POST: Student/Delete
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            if (_context.Students==null)
            {
                return Problem("Entity set 'AcademyContext.Students' is null");
            }

            var student = await _context.Students.FindAsync(id);

            if(student!=null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            //else
            //{
            //    return NotFound();
            //}
            
            return RedirectToAction(nameof(Index));
        }
        //=============================================================
        // Student Exists
        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(s => s.Id == id)).GetValueOrDefault();
        }
	}
}

using ASP_NET_Core_MVC_Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_MVC_Academy.Controllers
{
    public class StudentController : Controller
    {
        private readonly AcademyContext _context;

        public StudentController(AcademyContext context)
        {
            _context = context;
        }
        //=============================================================================================        
        // GET: Student/Index
        public async Task<IActionResult> Index()
        {
            var academyContext = _context.Students.Include(s => s.Group);
            return View(await _context.Students.ToListAsync());
        }
		//=============================================================================================
		// GET: Student/Details
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students==null)
            {
                return NotFound();
            }
            
            var students = await _context.Students.Include(s=>s.Group).FirstOrDefaultAsync(m=>m.Id==id);

            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }
		//=============================================================================================
		// GET: Student/Create
		public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }
		
		// POST: Student/Create
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,EMail,GroupId")] Student students)
        {
            try
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }
        }
		//=============================================================================================
		// GET: Student/Edit
		public async Task<IActionResult>Edit(int? id)
        {
            if (id==null || _context.Students==null)
            {
                return NotFound();
            }

            var 
        }

		// POST: Student/Edit

		//=============================================================================================
		// GET: Student/Delete
		// POST: Student/Delete

	}
}

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
		// Метод для отображения списка студентов
		public async Task<IActionResult> Index()
        {
            var academyContext = _context.Students.Include(s => s.Group);
            return View(await _context.Students.ToListAsync());
        }
		//=============================================================
		// GET: Student/Details
		// Метод для отображения деталей студента
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
		// Метод для отображения формы создания нового студента
		public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }

		// POST: Student/Create
		// Метод для обработки данных формы создания нового студента
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,EMail,GroupId")] Student student)
        {
			// Проверка на существование студента с таким же именем в базе данных
			if (_context.Students.Any(s=>s.Name==student.Name))
            {
                ModelState.AddModelError("Name", "Студент с таким именем уже существует");
            }

			// Проверка на существование студента с таким же e-mail в базе данных
			if (_context.Students.Any(s => s.EMail == student.EMail))
			{
				ModelState.AddModelError("EMail", "Студент с таким e-mail уже существует");
			}

			// Если модель проходит валидацию, сохраняем студента в базе данных
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
		// Метод для отображения формы редактирования студента
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

		// Метод для обработки данных формы редактирования студента
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
		// Метод для отображения формы удаления студента
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
		// Метод для обработки данных формы удаления студента
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
		// Метод для проверки существования студента по его id
		private bool StudentExists(int id)
        {
            return (_context.Students?.Any(s => s.Id == id)).GetValueOrDefault();
        }
	}
}

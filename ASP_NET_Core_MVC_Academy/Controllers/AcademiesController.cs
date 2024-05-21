using ASP_NET_Core_MVC_Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_MVC_Academy.Controllers
{
    public class AcademiesController : Controller
    {
        private readonly AcademyContext _context;

        public AcademiesController(AcademyContext context)
        {
            _context = context;
        }
        //=============================================================
        // GET: Academy/Index
        public async Task< IActionResult> Index()
        {
            return _context.Academies != null ? 
                View(await _context.Academies.ToListAsync()) : 
                Problem("Entity set 'ASP_NET_Core_MVC_Academy.Academies' is null.");
            
            // можно и так 
            //return View(await _context.Academies.ToListAsync());
        }
        //=============================================================
        // GET: Academy/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Academies == null)
            {
                return NotFound();
            }

            var group = await _context.Academies.FirstOrDefaultAsync(m => m.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        //=============================================================
        // GET: Academy/Create
        public IActionResult Create()
        {            
            return View();
        }

        // POST: Academy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EMail")] Academy academy)
        {
			try
			{
				_context.Add(academy);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

		}
        //=============================================================
        // GET: Academy/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Academies == null)
            {
                return NotFound();
            }

            var academy = await _context.Academies.FindAsync(id);

            if (academy == null)
            {
                return NotFound();
            }
                        
            return View(academy);
        }
        // POST: Academy/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EMail")] Academy academy)
        {
            if (id != academy.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(academy);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademyExists(academy.Id))
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
        // GET: Academy/Delete
        public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Academies == null)
			{
				return NotFound();
			}

			var academy = await _context.Academies.FirstOrDefaultAsync(m => m.Id == id);

			if (academy == null)
			{
				return NotFound();
			}

			return View(academy);
		}
		// POST: Academy/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Academies == null)
			{
				return Problem("Entity set 'AcademyContext.Academies' is null");
			}

			var academy = await _context.Academies.FindAsync(id);

			if (academy != null)
			{
				_context.Academies.Remove(academy);
				await _context.SaveChangesAsync();
			}
			//else
			//{
			//    return NotFound();
			//}

			return RedirectToAction(nameof(Index));
		}
        //=============================================================
        // Academy Exists
        private bool AcademyExists(int id)
        {
            return (_context.Academies?.Any(g => g.Id == id)).GetValueOrDefault();
        }
    }
}

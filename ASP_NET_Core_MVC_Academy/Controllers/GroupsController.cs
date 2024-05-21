using ASP_NET_Core_MVC_Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_MVC_Academy.Controllers
{
    public class GroupsController : Controller
    {
        public readonly AcademyContext _context;

        public GroupsController(AcademyContext context)
        {
            _context = context;
        }
        //=============================================================
        // GET: Group/Index
        public async Task<IActionResult> Index()
        {
            return View( await _context.Groups.ToListAsync());
        }
        //=============================================================
        // GET: Group/Details
        public async Task<IActionResult>Details(int? id)
        {
            if (id == null || _context.Groups==null)
            {
                return NotFound();
            }

            var group=await _context.Groups.Include(s=>s.Academy).FirstOrDefaultAsync(m=>m.Id==id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }
                
        //=============================================================
        // GET: Group/Create
        public IActionResult Create()
        {
            ViewData["AcademyId"] = new SelectList(_context.Academies, "Id", "Name");
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Teacher,EMail,AcademyId")] Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AcademyId"] = new SelectList(_context.Academies, "Id", "Name", group.AcademyId);
            return View(group);
        }

		//=============================================================
		// GET: Group/Edit
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Groups== null)
			{
				return NotFound();
			}

			var group = await _context.Groups.FindAsync(id);

			if (group == null)
			{
				return NotFound();
			}

			//ViewBag.GroupId = new SelectList(_context.Groups, "Id", "Name", students.GroupId);
			ViewData["AcademyId"] = new SelectList(_context.Groups, "Id", "Name", group.AcademyId);
			return View(group);
		}

        // POST: Group/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Teacher,EMail,AcademyId")] Group group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(group);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(group.Id))
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
        // GET: Group/Delete
        public async Task<IActionResult>Delete(int? id)
        {
            if (id ==null || _context.Groups==null)
            {
                return NotFound();
            }

            var group=await _context.Groups.Include(g=>g.Academy).FirstOrDefaultAsync(m=>m.Id==id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }
		// POST: Group/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Groups == null)
			{
				return Problem("Entity set 'AcademyContext.Groups' is null");
			}

			var group = await _context.Groups.FindAsync(id);

			if (group != null)
			{
				_context.Groups.Remove(group);
				await _context.SaveChangesAsync();
			}
			//else
			//{
			//    return NotFound();
			//}

			return RedirectToAction(nameof(Index));
		}
		//=============================================================
		// Group Exists
        private bool GroupExists(int id)
        {
            return (_context.Groups?.Any(g => g.Id == id)).GetValueOrDefault();
        }

	}
}

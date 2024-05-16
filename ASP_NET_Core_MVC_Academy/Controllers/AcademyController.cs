using ASP_NET_Core_MVC_Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_MVC_Academy.Controllers
{
    public class AcademyController : Controller
    {
        private readonly AcademyContext _context;

        public AcademyController(AcademyContext context)
        {
            _context = context;
        }

        // GET: Academy
        public async Task< IActionResult> Index()
        {
            return View(await _context.Academies.ToListAsync());
        }
    }
}

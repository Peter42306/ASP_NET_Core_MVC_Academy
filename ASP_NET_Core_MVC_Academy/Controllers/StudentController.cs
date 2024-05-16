using ASP_NET_Core_MVC_Academy.Models;
using Microsoft.AspNetCore.Mvc;
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

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
    }
}

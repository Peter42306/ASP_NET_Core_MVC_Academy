﻿using ASP_NET_Core_MVC_Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_MVC_Academy.Controllers
{
    public class GroupController : Controller
    {
        public readonly AcademyContext _context;

        public GroupController(AcademyContext context)
        {
            _context = context;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            return View( await _context.Groups.ToListAsync());
        }
    }
}

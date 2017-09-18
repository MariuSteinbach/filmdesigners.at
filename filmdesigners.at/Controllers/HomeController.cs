using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using filmdesigners.at.Models;
using Microsoft.AspNetCore.Authorization;
using filmdesigners.at.Data;
using Microsoft.EntityFrameworkCore;

namespace filmdesigners.at.Controllers
{
    [AllowAnonymous] 
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Chapter;
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult CreateHomeIndexChapter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHomeIndexChapter(Chapter chapter)
        {
            if(ModelState.IsValid)
            {
                chapter.Page = "HomeIndex";
                _context.Add(chapter);
                await _context.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            }
            return View(chapter);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
using Microsoft.AspNetCore.Identity;
using filmdesigners.at.Authorization;

namespace filmdesigners.at.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Chapter;
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Chapter chapter)
        {
            if(ModelState.IsValid)
            {
                var isAuthorized = await _authorizationService.AuthorizeAsync(User, chapter, ChapterOperations.Create);

                if (!isAuthorized.Succeeded)
                {
                    return new ChallengeResult();
                }
                _context.Add(chapter);
                await _context.SaveChangesAsync();
                RedirectToAction("Index");
            }
            return View(chapter);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapter.SingleOrDefaultAsync(c => c.ChapterID == id);
            if (chapter == null)
            {
                return NotFound();
            }
            return View(chapter);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ChapterID,Heading,Text,Page")] Chapter chapter)
        {
            if (id != chapter.ChapterID)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, chapter, ChapterOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chapter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChapterExists(chapter.ChapterID))
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
            return View(chapter);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapter
                .SingleOrDefaultAsync(c => c.ChapterID == id);
            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chapter = await _context.Chapter.SingleOrDefaultAsync(c => c.ChapterID == id);
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, chapter, ChapterOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }
            _context.Chapter.Remove(chapter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool ChapterExists(string id)
        {
            return _context.Chapter.Any(c => c.ChapterID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using filmdesigners.at.Data;
using filmdesigners.at.Models;
using Microsoft.AspNetCore.Authorization;

namespace filmdesigners.at.Controllers
{
    public class AwardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AwardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Awards
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Award.Include(a => a.Job).Include(a => a.Member).Include(a => a.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Awards/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Award
                .Include(a => a.Job)
                .Include(a => a.Member)
                .Include(a => a.Project)
                .SingleOrDefaultAsync(m => m.AwardID == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // GET: Awards/Create
        public IActionResult Create()
        {
            ViewData["JobID"] = new SelectList(_context.Job, "JobId", "JobId");
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "MemberId");
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID");
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AwardID,MemberID,ProjectID,JobID,Name,Date,Category")] Award award)
        {
            if (ModelState.IsValid)
            {
                _context.Add(award);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobID"] = new SelectList(_context.Job, "JobId", "JobId", award.JobID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "MemberId", award.MemberID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID", award.ProjectID);
            return View(award);
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Award.SingleOrDefaultAsync(m => m.AwardID == id);
            if (award == null)
            {
                return NotFound();
            }
            ViewData["JobID"] = new SelectList(_context.Job, "JobId", "JobId", award.JobID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "MemberId", award.MemberID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID", award.ProjectID);
            return View(award);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AwardID,MemberID,ProjectID,JobID,Name,Date,Category")] Award award)
        {
            if (id != award.AwardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(award);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardExists(award.AwardID))
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
            ViewData["JobID"] = new SelectList(_context.Job, "JobId", "JobId", award.JobID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "MemberId", award.MemberID);
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "ProjectID", award.ProjectID);
            return View(award);
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Award
                .Include(a => a.Job)
                .Include(a => a.Member)
                .Include(a => a.Project)
                .SingleOrDefaultAsync(m => m.AwardID == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var award = await _context.Award.SingleOrDefaultAsync(m => m.AwardID == id);
            _context.Award.Remove(award);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardExists(string id)
        {
            return _context.Award.Any(e => e.AwardID == id);
        }
    }
}

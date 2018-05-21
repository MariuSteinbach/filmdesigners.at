using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using filmdesigners.at.Data;
using filmdesigners.at.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace filmdesigners.at.Controllers
{
    public class DSGVOAnswersController : Controller
    {
        private readonly ApplicationDbContext _context;
		private IHttpContextAccessor _accessor;

		public DSGVOAnswersController(ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
			_accessor = accessor;
        }

        // GET: DSGVOAnswers
        public async Task<IActionResult> Index()
        {
            return View(await _context.DSGVOAnswer.ToListAsync());
        }

		// GET: Accept
        [AllowAnonymous]
		public async Task<IActionResult> Accept(int? member, string email)
		{
            if(member == null || email == null)
			{
				return BadRequest();
			}
            
			var DSGVOAnswer = await _context.DSGVOAnswer
											.SingleOrDefaultAsync(m => m.Member == member);
			if (DSGVOAnswer != null)
			{
				//UPDATE
				DSGVOAnswer.Accepted = true;
				_context.Update(DSGVOAnswer);
				await _context.SaveChangesAsync();
				return View(DSGVOAnswer);
			}
			else
			{
				DSGVOAnswer = new DSGVOAnswer
				{
					Member = (int)member,
					Email = email,
					Accepted = true,
					AcceptedAt = DateTime.UtcNow,
					AcceptedFrom = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
				};
				_context.Add(DSGVOAnswer);
				await _context.SaveChangesAsync();
				return View(DSGVOAnswer);
			}
		}
        
		[AllowAnonymous]
        public async Task<IActionResult> Decline(int? member, string email)
        {
            if (member == null || email == null)
            {
                return BadRequest();
            }

            var DSGVOAnswer = await _context.DSGVOAnswer
                                            .SingleOrDefaultAsync(m => m.Member == member);
            if (DSGVOAnswer != null)
            {
				//UPDATE
				DSGVOAnswer.Accepted = false;
                _context.Update(DSGVOAnswer);
                await _context.SaveChangesAsync();
                return View(DSGVOAnswer);
            }
            else
            {
                DSGVOAnswer = new DSGVOAnswer
                {
                    Member = (int)member,
                    Email = email,
                    Accepted = false,
                    AcceptedAt = DateTime.UtcNow,
                    AcceptedFrom = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
                };
                _context.Add(DSGVOAnswer);
                await _context.SaveChangesAsync();
                return View(DSGVOAnswer);
            }
        }
        // GET: DSGVOAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dSGVOAnswer = await _context.DSGVOAnswer
                .SingleOrDefaultAsync(m => m.ID == id);
            if (dSGVOAnswer == null)
            {
                return NotFound();
            }

            return View(dSGVOAnswer);
        }

        // GET: DSGVOAnswers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DSGVOAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,Accepted,AcceptedAt,AcceptedFrom")] DSGVOAnswer dSGVOAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dSGVOAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dSGVOAnswer);
        }

        // GET: DSGVOAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dSGVOAnswer = await _context.DSGVOAnswer.SingleOrDefaultAsync(m => m.ID == id);
            if (dSGVOAnswer == null)
            {
                return NotFound();
            }
            return View(dSGVOAnswer);
        }

        // POST: DSGVOAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,Accepted,AcceptedAt,AcceptedFrom")] DSGVOAnswer dSGVOAnswer)
        {
            if (id != dSGVOAnswer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dSGVOAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DSGVOAnswerExists(dSGVOAnswer.ID))
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
            return View(dSGVOAnswer);
        }

        // GET: DSGVOAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dSGVOAnswer = await _context.DSGVOAnswer
                .SingleOrDefaultAsync(m => m.ID == id);
            if (dSGVOAnswer == null)
            {
                return NotFound();
            }

            return View(dSGVOAnswer);
        }

        // POST: DSGVOAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dSGVOAnswer = await _context.DSGVOAnswer.SingleOrDefaultAsync(m => m.ID == id);
            _context.DSGVOAnswer.Remove(dSGVOAnswer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DSGVOAnswerExists(int id)
        {
            return _context.DSGVOAnswer.Any(e => e.ID == id);
        }
    }
}

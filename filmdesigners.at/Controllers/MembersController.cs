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
using Microsoft.AspNetCore.Identity;
using filmdesigners.at.Authorization;
using filmdesigners.at.Models.MemberViewModels;
using filmdesigners.at.Services;

namespace filmdesigners.at.Controllers
{
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public MembersController(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: Members
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var Jobs = _context.Job.ToArray();
            ViewData["Jobs"] = Jobs;
            return View(await _context.Member.ToListAsync());
        }

        // GET: Members/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .Include(m => m.Enrollments)
                .ThenInclude(e => e.Project)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "Name");
            ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Name");
            ViewData["JobID"] = new SelectList(_context.Job, "JobId", "Name");
            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            member.OwnerID = _userManager.GetUserId(User);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Create);

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            _context.Add(member);

            await _context.SaveChangesAsync();

            await _emailSender.SendEmailAsync("m@steinbach.io", "New Member",
                   $"Please approve or reject the new Member " + member.Name + ".");

            return RedirectToAction("Index");
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.SingleOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Update);

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            ViewData["JobID"] = new SelectList(_context.Job, "JobId", "Name");
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MemberEditViewModel editModel)
        {
            if(!ModelState.IsValid)
            {
                return View(editModel);
            }

            // Get Member from DB to get OwnerID
            var member = await _context.Member.SingleOrDefaultAsync(m => m.MemberId == id);
            if(member == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Update);

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            member = viewModel2Model(member, editModel);

            if(member.Status == Models.MemberStatus.Approved)
            {
                // If the Model was updated after the approval,
                // and the user cannpt approve, set the status back to submitted.
                var canApprove = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Approve);

                if(!canApprove.Succeeded)
                {
                    member.Status = Models.MemberStatus.Submitted;
                }
            }
            _context.Update(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .SingleOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Delete);

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.SingleOrDefaultAsync(m => m.MemberId == id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Delete);

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Members/SetStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetStatus(int id, Models.MemberStatus status)
        {
            var member = await _context.Member.SingleOrDefaultAsync(m => m.MemberId == id);

            var memberOperation = (status == Models.MemberStatus.Approved) ? MemberOperations.Approve : MemberOperations.Reject;

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member, memberOperation);

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            member.Status = status;

            _context.Member.Update(member);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.MemberId == id);
        }

        private Member viewModel2Model(Member member, MemberEditViewModel editViewModel)
        {
            member.Name = editViewModel.Name;
            member.JobId = editViewModel.JobId;
            member.Male = editViewModel.Male;
            member.Street = editViewModel.Street;
            member.ZIP = editViewModel.ZIP;
            member.City = editViewModel.City;
            member.Country = editViewModel.Country;
            member.Website = editViewModel.Website;
            member.Fax = editViewModel.Fax;
            member.Mobile = editViewModel.Mobile;
            member.Phone = editViewModel.Phone;
            member.OtherContact = editViewModel.OtherContact;
            member.Birthday = editViewModel.Birthday;
            member.Deathday = editViewModel.Deathday;
            if(editViewModel.Picture != null)
            {
                member.Picture = editViewModel.Picture;
            }
            member.Languages = editViewModel.Languages;
            member.InternationalExperiences = editViewModel.InternationalExperiences;
            member.Education = editViewModel.Education;
            member.Activities = editViewModel.Activities;
            member.Galleries = editViewModel.Galleries;
            member.Awards = editViewModel.Awards;
            member.Notes = editViewModel.Notes;
            member.EMail = editViewModel.EMail;

            return member;
        }
    }
}

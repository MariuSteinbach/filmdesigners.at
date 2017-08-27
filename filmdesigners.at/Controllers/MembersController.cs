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

namespace filmdesigners.at.Controllers
{
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MembersController(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.Member.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create(MemberEditViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            var member = ViewModel_to_model(new Member(), editModel);

            member.OwnerID = _userManager.GetUserId(User);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Create);

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            _context.Add(member);
            await _context.SaveChangesAsync();

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

            // Fetch Member from DB to get OwnerID
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

            member = ViewModel_to_model(member, editModel);

            if (member.Status == Models.MemberStatus.Approved)
            {
                // if the member is updated after the approval,
                // and the user cannot approve, set the status back to submitted
                var canApprove = await _authorizationService.AuthorizeAsync(User, member, MemberOperations.Approve);

                if (!canApprove.Succeeded)
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
            return RedirectToAction("Index");
        }

        // POST: Members/SetState/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetStatus(int id, Models.MemberStatus status)
        {
            var member = await _context.Member.SingleOrDefaultAsync(m => m.MemberId == id);

            var contactOperation = (status == Models.MemberStatus.Approved) ? MemberOperations.Approve
                                                                      : MemberOperations.Reject;

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, member,
                                        contactOperation);
            if (!isAuthorized.Succeeded)
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

        private Member ViewModel_to_model(Member member, MemberEditViewModel editModel)
        {
            member.Name = editModel.Name;

            return member;
        }

        private MemberEditViewModel Model_to_viewModel(Member member)
        {
            var editModel = new MemberEditViewModel();

            editModel.MemberId = member.MemberId;
            editModel.Name = member.Name;

            return editModel;
        }
    }
}

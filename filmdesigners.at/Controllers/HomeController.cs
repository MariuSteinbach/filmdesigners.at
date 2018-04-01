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
using System.IO;
using HtmlAgilityPack;

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
            var applicationDbContext = _context.Chapter.Where(c => c.Page == "HomeIndex").OrderByDescending(c => c.Created);
            ViewData["SubPage"] = "Index";
            return View(await applicationDbContext.ToListAsync());
            
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(string query)
        {
            if(query.Length > 2)
            {
                SearchResult Result = new SearchResult();
                Result.Awards = await _context.Award.Where(a => a.Name.Contains(query)).ToListAsync();
                Result.Chapter = await _context.Chapter.Where(c => c.Heading.Contains(query)).ToListAsync();
                Result.Event = await _context.Event.Where(e => e.Title.Contains(query)).ToListAsync();
                Result.Job = await _context.Job.Where(j => j.Name.Contains(query)).ToListAsync();
                Result.Member = await _context.Member.Where(m => m.Name.Contains(query)).ToListAsync();
                Result.Project = await _context.Project.Where(p => p.Name.Contains(query)).ToListAsync();
                return View(Result);
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Congratulations()
        {
            var applicationDbContext = _context.Chapter.Where(c => c.Page == "HomeCongratulations").OrderByDescending(c => c.Created);
            ViewData["SubPage"] = "Congratulations";
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
                chapter.Created = DateTime.Now;
                chapter.Edited = DateTime.Now;
                for (; ; )
                {
                    if (!chapter.Text.Contains("data:image"))
                    {
                        break;
                    }
                    Guid PictureID = Guid.NewGuid();
                    string fileType = chapter.Text.Split(new string[] { "data:image/" }, StringSplitOptions.None)[1].Split(';')[0];
                    string PicturesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{PictureID}.{fileType}");
                    string base64data = chapter.Text.Split(new string[] { "data:image/" }, StringSplitOptions.None)[1].Split(',')[1].Split('"')[0];
                    var bytes = Convert.FromBase64String(base64data);
                    if (bytes.Length > 0)
                    {
                        using (var stream = new FileStream(PicturesPath, FileMode.Create))
                        {
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Flush();
                        }
                    }
                    chapter.Text = chapter.Text.Replace($"data:image/{fileType};base64,{base64data}", $"/images/{PictureID}.{fileType}").Replace("data-filename", "alt");
                }
                // Make Images responsive
                HtmlDocument Document = new HtmlDocument();
                Document.LoadHtml(chapter.Text);
                IEnumerable<HtmlNode> Images = Document
                    .DocumentNode
                    .Descendants("img").ToList();
                foreach(HtmlNode Image in Document
                    .DocumentNode
                    .Descendants("img").ToList())
                {
                    Image.Attributes.Add("class", "img-fluid");
                }
                chapter.Text = Document.DocumentNode.OuterHtml;
                _context.Add(chapter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
                for (; ; )
                {
                    if (!chapter.Text.Contains("data:image"))
                    {
                        break;
                    }
                    Guid PictureID = Guid.NewGuid();
                    string fileType = chapter.Text.Split(new string[] { "data:image/" }, StringSplitOptions.None)[1].Split(';')[0];
                    string PicturesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{PictureID}.{fileType}");
                    string base64data = chapter.Text.Split(new string[] { "data:image/" }, StringSplitOptions.None)[1].Split(',')[1].Split('"')[0];
                    var bytes = Convert.FromBase64String(base64data);
                    if (bytes.Length > 0)
                    {
                        using (var stream = new FileStream(PicturesPath, FileMode.Create))
                        {
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Flush();
                        }
                    }
                    chapter.Text = chapter.Text.Replace($"data:image/{fileType};base64,{base64data}", $"/images/{PictureID}.{fileType}").Replace("data-filename", "alt");
                }
                // Make Images responsive
                HtmlDocument Document = new HtmlDocument();
                Document.LoadHtml(chapter.Text);
                IEnumerable<HtmlNode> Images = Document
                    .DocumentNode
                    .Descendants("img").ToList();
                foreach (HtmlNode Image in Document
                    .DocumentNode
                    .Descendants("img").ToList())
                {
                    Image.Attributes.Add("class", "img-fluid");
                }
                chapter.Text = Document.DocumentNode.OuterHtml;
                chapter.Edited = DateTime.Now;
                try
                {
                    var oldchapter = await _context.Chapter
                       .AsNoTracking()
                       .SingleOrDefaultAsync(c => c.ChapterID == chapter.ChapterID);
                    chapter.Created = oldchapter.Created;
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

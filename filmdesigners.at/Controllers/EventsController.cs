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
using System.IO;

namespace filmdesigners.at.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.OrderByDescending(e => e.Date).ToListAsync());
        }

        // GET: Events/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event created)
        {
            if (ModelState.IsValid)
            {
                created.Created = DateTime.Now;
                // create file with picture
                if (created.Picture != null)
                {
                    Guid PictureID = Guid.NewGuid();
                    string fileType = created.Picture.Split('/')[1].Split(';')[0];
                    string PicturesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{PictureID}.{fileType}");

                    var bytes = Convert.FromBase64String(created.Picture.Split(',')[1]);
                    if (bytes.Length > 0)
                    {
                        using (var stream = new FileStream(PicturesPath, FileMode.Create))
                        {
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Flush();
                        }
                    }
                    created.Picture = $"{PictureID.ToString()}.{fileType}";
                }
                _context.Add(created);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(created);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EventID,Title,Picture,Teaser,Text,Date,Created")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (@event.Picture != null)
                    {
                        Guid PictureID = Guid.NewGuid();
                        string fileType = @event.Picture.Split('/')[1].Split(';')[0];
                        string PicturesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{PictureID}.{fileType}");

                        var bytes = Convert.FromBase64String(@event.Picture.Split(',')[1]);
                        if (bytes.Length > 0)
                        {
                            using (var stream = new FileStream(PicturesPath, FileMode.Create))
                            {
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Flush();
                            }
                        }
                        @event.Picture = $"{PictureID.ToString()}.{fileType}";
                    }
                    else{
                        @event.Picture = _context.Event.Where(e => e.EventID == id).AsNoTracking().First().Picture;
                    }
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var @event = await _context.Event.SingleOrDefaultAsync(m => m.EventID == id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(string id)
        {
            return _context.Event.Any(e => e.EventID == id);
        }
    }
}

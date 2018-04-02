/******************************************************************************/
/*                                                                            */
/* CONFIDENTIAL                                                               */
/* __________________________________________________________________________ */
/*                                                                            */
/*  [2018] Marius Steinbach                                                   */
/*  All Rights Reserved.                                                      */
/*                                                                            */
/* NOTICE:  All information contained herein is, and remains                  */
/* the property of Marius Steinbach.                                          */
/* The intellectual and technical concepts contained                          */
/* herein are proprietary to Marius Steinbach                                 */
/* and are protected by trade secret or copyright law.                        */
/* Dissemination of this information or reproduction of this material         */
/* is strictly forbidden unless prior written permission is obtained          */
/* from Marius Steinbach.                                                     */
/*                                                                            */
/******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using filmdesigners.at.Data;
using filmdesigners.at.Models;

namespace filmdesigners.at.Controllers
{
    public class OldUrlsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OldUrlsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OldUrls
        public async Task<IActionResult> Index()
        {
            return View(await _context.OldUrl.ToListAsync());
        }

        // GET: OldUrls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oldUrl = await _context.OldUrl
                .SingleOrDefaultAsync(m => m.OldUrlID == id);
            if (oldUrl == null)
            {
                return NotFound();
            }

            return View(oldUrl);
        }

        // GET: OldUrls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OldUrls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OldUrlID,URL,MemberID")] OldUrl oldUrl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oldUrl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oldUrl);
        }

        // GET: OldUrls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oldUrl = await _context.OldUrl.SingleOrDefaultAsync(m => m.OldUrlID == id);
            if (oldUrl == null)
            {
                return NotFound();
            }
            return View(oldUrl);
        }

        // POST: OldUrls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OldUrlID,URL,MemberID")] OldUrl oldUrl)
        {
            if (id != oldUrl.OldUrlID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oldUrl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OldUrlExists(oldUrl.OldUrlID))
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
            return View(oldUrl);
        }

        // GET: OldUrls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oldUrl = await _context.OldUrl
                .SingleOrDefaultAsync(m => m.OldUrlID == id);
            if (oldUrl == null)
            {
                return NotFound();
            }

            return View(oldUrl);
        }

        // POST: OldUrls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var oldUrl = await _context.OldUrl.SingleOrDefaultAsync(m => m.OldUrlID == id);
            _context.OldUrl.Remove(oldUrl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OldUrlExists(string id)
        {
            return _context.OldUrl.Any(e => e.OldUrlID == id);
        }
    }
}

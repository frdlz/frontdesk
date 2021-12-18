using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Frontdesk6.Data;
using Frontdesk6.Models.Frontdesk;

namespace Frontdesk6.Controllers
{
    public class LayananFrontdesksController : Controller
    {
        private readonly Frontdesk6Context _context;

        public LayananFrontdesksController(Frontdesk6Context context)
        {
            _context = context;
        }

        // GET: LayananFrontdesks
        public async Task<IActionResult> Index()
        {
            return View(await _context.LayananFrontdesk.ToListAsync());
        }

        // GET: LayananFrontdesks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var layananFrontdesk = await _context.LayananFrontdesk
                .FirstOrDefaultAsync(m => m.LayananFrontdeskID == id);
            if (layananFrontdesk == null)
            {
                return NotFound();
            }

            return View(layananFrontdesk);
        }

        // GET: LayananFrontdesks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LayananFrontdesks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LayananFrontdeskID,NamaLayanan")] LayananFrontdesk layananFrontdesk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(layananFrontdesk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(layananFrontdesk);
        }

        // GET: LayananFrontdesks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var layananFrontdesk = await _context.LayananFrontdesk.FindAsync(id);
            if (layananFrontdesk == null)
            {
                return NotFound();
            }
            return View(layananFrontdesk);
        }

        // POST: LayananFrontdesks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LayananFrontdeskID,NamaLayanan")] LayananFrontdesk layananFrontdesk)
        {
            if (id != layananFrontdesk.LayananFrontdeskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(layananFrontdesk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LayananFrontdeskExists(layananFrontdesk.LayananFrontdeskID))
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
            return View(layananFrontdesk);
        }

        // GET: LayananFrontdesks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var layananFrontdesk = await _context.LayananFrontdesk
                .FirstOrDefaultAsync(m => m.LayananFrontdeskID == id);
            if (layananFrontdesk == null)
            {
                return NotFound();
            }

            return View(layananFrontdesk);
        }

        // POST: LayananFrontdesks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var layananFrontdesk = await _context.LayananFrontdesk.FindAsync(id);
            _context.LayananFrontdesk.Remove(layananFrontdesk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LayananFrontdeskExists(int id)
        {
            return _context.LayananFrontdesk.Any(e => e.LayananFrontdeskID == id);
        }
    }
}

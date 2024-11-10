using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudySharesController : Controller
    {
        private readonly WebApplication1Context _context;

        public StudySharesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: StudyShares
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudyShare.ToListAsync());
        }

        // GET: StudyShares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyShare = await _context.StudyShare
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyShare == null)
            {
                return NotFound();
            }

            return View(studyShare);
        }

        // GET: StudyShares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudyShares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Type,Subject,Description,Url,Tags,FilePath,CreatedAt")] StudyShare studyShare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyShare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studyShare);
        }

        // GET: StudyShares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyShare = await _context.StudyShare.FindAsync(id);
            if (studyShare == null)
            {
                return NotFound();
            }
            return View(studyShare);
        }

        // POST: StudyShares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type,Subject,Description,Url,Tags,FilePath,CreatedAt")] StudyShare studyShare)
        {
            if (id != studyShare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyShare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyShareExists(studyShare.Id))
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
            return View(studyShare);
        }

        // GET: StudyShares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyShare = await _context.StudyShare
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyShare == null)
            {
                return NotFound();
            }

            return View(studyShare);
        }

        // POST: StudyShares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyShare = await _context.StudyShare.FindAsync(id);
            if (studyShare != null)
            {
                _context.StudyShare.Remove(studyShare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyShareExists(int id)
        {
            return _context.StudyShare.Any(e => e.Id == id);
        }
    }
}

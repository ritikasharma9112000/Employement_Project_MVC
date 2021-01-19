using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employement_Project_MVC.Data;
using Employement_Project_MVC.Models;

namespace Employement_Project_MVC.Controllers
{
    public class Apply_Job_DetailController : Controller
    {
        private readonly Employement_Project_MVCContext _context;

        public Apply_Job_DetailController(Employement_Project_MVCContext context)
        {
            _context = context;
        }

        // GET: Apply_Job_Detail
        public async Task<IActionResult> Index()
        {
            var employement_Project_MVCContext = _context.Apply_Job_Detail.Include(a => a.Candidate_Detail).Include(a => a.Job_Detail);
            return View(await employement_Project_MVCContext.ToListAsync());
        }

        // GET: Apply_Job_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_Job_Detail = await _context.Apply_Job_Detail
                .Include(a => a.Candidate_Detail)
                .Include(a => a.Job_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apply_Job_Detail == null)
            {
                return NotFound();
            }

            return View(apply_Job_Detail);
        }

        // GET: Apply_Job_Detail/Create
        public IActionResult Create()
        {
            ViewData["Candidate_DetailId"] = new SelectList(_context.Candidate_Detail, "Id", "Mobile_no_of_candidate");
            ViewData["Job_DetailId"] = new SelectList(_context.Set<Job_Detail>(), "Id", "Id");
            return View();
        }

        // POST: Apply_Job_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Candidate_DetailId,Job_DetailId,Candidate_availabilities,Candidate_notice_period")] Apply_Job_Detail apply_Job_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apply_Job_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Candidate_DetailId"] = new SelectList(_context.Candidate_Detail, "Id", "Mobile_no_of_candidate", apply_Job_Detail.Candidate_DetailId);
            ViewData["Job_DetailId"] = new SelectList(_context.Set<Job_Detail>(), "Id", "Id", apply_Job_Detail.Job_DetailId);
            return View(apply_Job_Detail);
        }

        // GET: Apply_Job_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_Job_Detail = await _context.Apply_Job_Detail.FindAsync(id);
            if (apply_Job_Detail == null)
            {
                return NotFound();
            }
            ViewData["Candidate_DetailId"] = new SelectList(_context.Candidate_Detail, "Id", "Mobile_no_of_candidate", apply_Job_Detail.Candidate_DetailId);
            ViewData["Job_DetailId"] = new SelectList(_context.Set<Job_Detail>(), "Id", "Id", apply_Job_Detail.Job_DetailId);
            return View(apply_Job_Detail);
        }

        // POST: Apply_Job_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Candidate_DetailId,Job_DetailId,Candidate_availabilities,Candidate_notice_period")] Apply_Job_Detail apply_Job_Detail)
        {
            if (id != apply_Job_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apply_Job_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Apply_Job_DetailExists(apply_Job_Detail.Id))
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
            ViewData["Candidate_DetailId"] = new SelectList(_context.Candidate_Detail, "Id", "Mobile_no_of_candidate", apply_Job_Detail.Candidate_DetailId);
            ViewData["Job_DetailId"] = new SelectList(_context.Set<Job_Detail>(), "Id", "Id", apply_Job_Detail.Job_DetailId);
            return View(apply_Job_Detail);
        }

        // GET: Apply_Job_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_Job_Detail = await _context.Apply_Job_Detail
                .Include(a => a.Candidate_Detail)
                .Include(a => a.Job_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apply_Job_Detail == null)
            {
                return NotFound();
            }

            return View(apply_Job_Detail);
        }

        // POST: Apply_Job_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apply_Job_Detail = await _context.Apply_Job_Detail.FindAsync(id);
            _context.Apply_Job_Detail.Remove(apply_Job_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Apply_Job_DetailExists(int id)
        {
            return _context.Apply_Job_Detail.Any(e => e.Id == id);
        }
    }
}

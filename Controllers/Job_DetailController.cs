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
    public class Job_DetailController : Controller
    {
        private readonly Employement_Project_MVCContext _context;

        public Job_DetailController(Employement_Project_MVCContext context)
        {
            _context = context;
        }

        // GET: Job_Detail
        public async Task<IActionResult> Index()
        {
            var employement_Project_MVCContext = _context.Job_Detail.Include(j => j.Employer_Detail);
            return View(await employement_Project_MVCContext.ToListAsync());
        }

        // GET: Job_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Detail = await _context.Job_Detail
                .Include(j => j.Employer_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job_Detail == null)
            {
                return NotFound();
            }

            return View(job_Detail);
        }

        // GET: Job_Detail/Create
        public IActionResult Create()
        {
            ViewData["Employer_DetailId"] = new SelectList(_context.Employer_Detail, "Id", "Id");
            return View();
        }

        // POST: Job_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Job_role,Job_type,Job_salary,Job_description,Employer_DetailId")] Job_Detail job_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employer_DetailId"] = new SelectList(_context.Employer_Detail, "Id", "Id", job_Detail.Employer_DetailId);
            return View(job_Detail);
        }

        // GET: Job_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Detail = await _context.Job_Detail.FindAsync(id);
            if (job_Detail == null)
            {
                return NotFound();
            }
            ViewData["Employer_DetailId"] = new SelectList(_context.Employer_Detail, "Id", "Id", job_Detail.Employer_DetailId);
            return View(job_Detail);
        }

        // POST: Job_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Job_role,Job_type,Job_salary,Job_description,Employer_DetailId")] Job_Detail job_Detail)
        {
            if (id != job_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Job_DetailExists(job_Detail.Id))
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
            ViewData["Employer_DetailId"] = new SelectList(_context.Employer_Detail, "Id", "Id", job_Detail.Employer_DetailId);
            return View(job_Detail);
        }

        // GET: Job_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Detail = await _context.Job_Detail
                .Include(j => j.Employer_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job_Detail == null)
            {
                return NotFound();
            }

            return View(job_Detail);
        }

        // POST: Job_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job_Detail = await _context.Job_Detail.FindAsync(id);
            _context.Job_Detail.Remove(job_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Job_DetailExists(int id)
        {
            return _context.Job_Detail.Any(e => e.Id == id);
        }
    }
}

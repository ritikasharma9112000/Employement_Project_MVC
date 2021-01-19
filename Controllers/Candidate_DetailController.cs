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
    public class Candidate_DetailController : Controller
    {
        private readonly Employement_Project_MVCContext _context;

        public Candidate_DetailController(Employement_Project_MVCContext context)
        {
            _context = context;
        }

        // GET: Candidate_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidate_Detail.ToListAsync());
        }

        // GET: Candidate_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate_Detail = await _context.Candidate_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidate_Detail == null)
            {
                return NotFound();
            }

            return View(candidate_Detail);
        }

        // GET: Candidate_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidate_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_of_candidate,DOB_of_candidate,Mobile_no_of_candidate,Email_address_of_candidate")] Candidate_Detail candidate_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidate_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate_Detail);
        }

        // GET: Candidate_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate_Detail = await _context.Candidate_Detail.FindAsync(id);
            if (candidate_Detail == null)
            {
                return NotFound();
            }
            return View(candidate_Detail);
        }

        // POST: Candidate_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_of_candidate,DOB_of_candidate,Mobile_no_of_candidate,Email_address_of_candidate")] Candidate_Detail candidate_Detail)
        {
            if (id != candidate_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Candidate_DetailExists(candidate_Detail.Id))
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
            return View(candidate_Detail);
        }

        // GET: Candidate_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate_Detail = await _context.Candidate_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidate_Detail == null)
            {
                return NotFound();
            }

            return View(candidate_Detail);
        }

        // POST: Candidate_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate_Detail = await _context.Candidate_Detail.FindAsync(id);
            _context.Candidate_Detail.Remove(candidate_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Candidate_DetailExists(int id)
        {
            return _context.Candidate_Detail.Any(e => e.Id == id);
        }
    }
}

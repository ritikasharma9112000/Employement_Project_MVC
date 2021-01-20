using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employement_Project_MVC.Data;
using Employement_Project_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Employement_Project_MVC.Controllers
{
    public class Employer_DetailController : Controller
    {
        private readonly Employement_Project_MVCContext _context;

        public Employer_DetailController(Employement_Project_MVCContext context)
        {
            _context = context;
        }

        // GET: Employer_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employer_Detail.ToListAsync());
        }

        // GET: Employer_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer_Detail = await _context.Employer_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employer_Detail == null)
            {
                return NotFound();
            }

            return View(employer_Detail);
        }
        [Authorize]
        // GET: Employer_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employer_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Employer_name,Date_of_establishment,Address_of_employer")] Employer_Detail employer_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employer_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employer_Detail);
        }
        [Authorize]
        // GET: Employer_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer_Detail = await _context.Employer_Detail.FindAsync(id);
            if (employer_Detail == null)
            {
                return NotFound();
            }
            return View(employer_Detail);
        }

        // POST: Employer_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Employer_name,Date_of_establishment,Address_of_employer")] Employer_Detail employer_Detail)
        {
            if (id != employer_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employer_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employer_DetailExists(employer_Detail.Id))
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
            return View(employer_Detail);
        }
        [Authorize]
        // GET: Employer_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer_Detail = await _context.Employer_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employer_Detail == null)
            {
                return NotFound();
            }

            return View(employer_Detail);
        }

        // POST: Employer_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employer_Detail = await _context.Employer_Detail.FindAsync(id);
            _context.Employer_Detail.Remove(employer_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employer_DetailExists(int id)
        {
            return _context.Employer_Detail.Any(e => e.Id == id);
        }
    }
}

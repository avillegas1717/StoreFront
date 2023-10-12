using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Controllers
{
    public class ConditionsController : Controller
    {
        private readonly StoreFrontContext _context;

        public ConditionsController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: Conditions
        public async Task<IActionResult> Index()
        {
              return _context.Conditions != null ? 
                          View(await _context.Conditions.ToListAsync()) :
                          Problem("Entity set 'StoreFrontContext.Conditions'  is null.");
        }

        // GET: Conditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conditions == null)
            {
                return NotFound();
            }

            var condition = await _context.Conditions
                .FirstOrDefaultAsync(m => m.ConditionId == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // GET: Conditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConditionId,ConditionName,ConditionDescripton")] Condition condition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condition);
        }

        // GET: Conditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conditions == null)
            {
                return NotFound();
            }

            var condition = await _context.Conditions.FindAsync(id);
            if (condition == null)
            {
                return NotFound();
            }
            return View(condition);
        }

        // POST: Conditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConditionId,ConditionName,ConditionDescripton")] Condition condition)
        {
            if (id != condition.ConditionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionExists(condition.ConditionId))
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
            return View(condition);
        }

        // GET: Conditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conditions == null)
            {
                return NotFound();
            }

            var condition = await _context.Conditions
                .FirstOrDefaultAsync(m => m.ConditionId == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // POST: Conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conditions == null)
            {
                return Problem("Entity set 'StoreFrontContext.Conditions'  is null.");
            }
            var condition = await _context.Conditions.FindAsync(id);
            if (condition != null)
            {
                _context.Conditions.Remove(condition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionExists(int id)
        {
          return (_context.Conditions?.Any(e => e.ConditionId == id)).GetValueOrDefault();
        }
    }
}

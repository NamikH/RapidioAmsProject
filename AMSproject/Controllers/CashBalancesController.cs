using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMSproject.Data;

namespace AMSproject.Controllers
{
    public class CashBalancesController : Controller
    {
        private readonly AMSprojectContext _context;

        public CashBalancesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: CashBalances
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashBalance.ToListAsync());
        }

        // GET: CashBalances/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashBalance = await _context.CashBalance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashBalance == null)
            {
                return NotFound();
            }

            return View(cashBalance);
        }

        // GET: CashBalances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashBalances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,CashId,Number,Defenition")] CashBalance cashBalance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashBalance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashBalance);
        }

        // GET: CashBalances/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashBalance = await _context.CashBalance.FindAsync(id);
            if (cashBalance == null)
            {
                return NotFound();
            }
            return View(cashBalance);
        }

        // POST: CashBalances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Amount,CashId,Number,Defenition")] CashBalance cashBalance)
        {
            if (id != cashBalance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashBalance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashBalanceExists(cashBalance.Id))
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
            return View(cashBalance);
        }

        // GET: CashBalances/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashBalance = await _context.CashBalance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashBalance == null)
            {
                return NotFound();
            }

            return View(cashBalance);
        }

        // POST: CashBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var cashBalance = await _context.CashBalance.FindAsync(id);
            _context.CashBalance.Remove(cashBalance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashBalanceExists(long id)
        {
            return _context.CashBalance.Any(e => e.Id == id);
        }
    }
}

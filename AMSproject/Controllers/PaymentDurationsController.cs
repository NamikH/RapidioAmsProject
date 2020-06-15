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
    public class PaymentDurationsController : Controller
    {
        private readonly AMSprojectContext _context;

        public PaymentDurationsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: PaymentDurations
        public async Task<IActionResult> Index()
        {
            var aMSprojectContext = _context.PaymentDuration.Include(p => p.Contract);
            return View(await aMSprojectContext.ToListAsync());
        }

        // GET: PaymentDurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDuration = await _context.PaymentDuration
                .Include(p => p.Contract)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentDuration == null)
            {
                return NotFound();
            }

            return View(paymentDuration);
        }

        // GET: PaymentDurations/Create
        public IActionResult Create()
        {
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id");
            return View();
        }

        // POST: PaymentDurations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractDetailId,PaymentDate,Reason,CreateDate")] PaymentDuration paymentDuration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentDuration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", paymentDuration.ContractDetailId);
            return View(paymentDuration);
        }

        // GET: PaymentDurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDuration = await _context.PaymentDuration.FindAsync(id);
            if (paymentDuration == null)
            {
                return NotFound();
            }
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", paymentDuration.ContractDetailId);
            return View(paymentDuration);
        }

        // POST: PaymentDurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractDetailId,PaymentDate,Reason,CreateDate")] PaymentDuration paymentDuration)
        {
            if (id != paymentDuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentDuration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentDurationExists(paymentDuration.Id))
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
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", paymentDuration.ContractDetailId);
            return View(paymentDuration);
        }

        // GET: PaymentDurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDuration = await _context.PaymentDuration
                .Include(p => p.Contract)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentDuration == null)
            {
                return NotFound();
            }

            return View(paymentDuration);
        }

        // POST: PaymentDurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentDuration = await _context.PaymentDuration.FindAsync(id);
            _context.PaymentDuration.Remove(paymentDuration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentDurationExists(int id)
        {
            return _context.PaymentDuration.Any(e => e.Id == id);
        }
    }
}

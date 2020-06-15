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
    public class PaymentsListsController : Controller
    {
        private readonly AMSprojectContext _context;

        public PaymentsListsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: PaymentsLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentsList.ToListAsync());
        }

        // GET: PaymentsLists/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentsList = await _context.PaymentsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentsList == null)
            {
                return NotFound();
            }

            return View(paymentsList);
        }

        // GET: PaymentsLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentsLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractDetailId,SupportTypeId,ObjectsId,Amount,SpDefenition,ObjNumber,CustomersId,MonthDept")] PaymentsList paymentsList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentsList);
        }

        // GET: PaymentsLists/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentsList = await _context.PaymentsList.FindAsync(id);
            if (paymentsList == null)
            {
                return NotFound();
            }
            return View(paymentsList);
        }

        // POST: PaymentsLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ContractDetailId,SupportTypeId,ObjectsId,Amount,SpDefenition,ObjNumber,CustomersId,MonthDept")] PaymentsList paymentsList)
        {
            if (id != paymentsList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsListExists(paymentsList.Id))
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
            return View(paymentsList);
        }

        // GET: PaymentsLists/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentsList = await _context.PaymentsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentsList == null)
            {
                return NotFound();
            }

            return View(paymentsList);
        }

        // POST: PaymentsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var paymentsList = await _context.PaymentsList.FindAsync(id);
            _context.PaymentsList.Remove(paymentsList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsListExists(long id)
        {
            return _context.PaymentsList.Any(e => e.Id == id);
        }
    }
}

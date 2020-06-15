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
    public class PaymentTransactionsController : Controller
    {
        private readonly AMSprojectContext _context;

        public PaymentTransactionsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: PaymentTransactions
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.PaymentTransactions.ToListAsync());
        //}

        public IActionResult Index(int TransactionTypeId, int CustomersId, int SupportTypeId, int CashId, DateTime begDate, DateTime endDate)
        {
            if (begDate.Year <= 1 && 1 >= endDate.Year && TransactionTypeId == 0 && CustomersId == 0 && SupportTypeId == 0 && CashId == 0)
            {
                var lineTotal = _context.PaymentTransactions.Sum(n => n.Amount);
                //ViewBag.Error = $"<span style=>{a.ToString()}</span><br>";
                ViewBag.Error = lineTotal.ToString();
                var a = _context.PaymentTransactions.OrderBy(c => c.PaymentsId).ToList();
                var b = a;
                return View(_context.PaymentTransactions.OrderBy(c => c.Id).ToList());
            }
            var generalTotal = _context.PaymentTransactions.Where(c => (TransactionTypeId == 0 || c.TransactionTypeId == TransactionTypeId)
                                                            && (CustomersId == 0 || c.CustomersId == CustomersId)
                                                            && (SupportTypeId == 0 || c.SupportTypeId == SupportTypeId)
                                                            && (CashId == 0 || c.CashId == CashId)
                                                            && (begDate.Year <= 1 && 1 >= endDate.Year || c.CreatedDate.Date >= begDate && c.CreatedDate.Date <= endDate)).Select(a => a.Amount).Sum();
            ViewBag.Error = generalTotal.ToString();

            return View(_context.PaymentTransactions.Where(c => (TransactionTypeId == 0 || c.TransactionTypeId == TransactionTypeId)
                                                            && (CustomersId == 0 || c.CustomersId == CustomersId)
                                                            && (SupportTypeId == 0 || c.SupportTypeId == SupportTypeId)
                                                            && (CashId == 0 || c.CashId == CashId)
                                                            && (begDate.Year <= 1 && 1 >= endDate.Year || c.CreatedDate.Date >= begDate && c.CreatedDate.Date <= endDate)).ToList());
        }

        public IActionResult FilterReport()
        {

            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition");
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "Defenition");
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id");
            //ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Name");
            ViewData["CustomersId"] = _context.Customers.Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Name + "   " + a.Surname }).ToList();

            ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition");
            ViewData["SupportTypeId"] = new SelectList(_context.SupportType, "Id", "Defenition");
            ViewData["ObjectsId"] = new SelectList(_context.Objects, "Id", "Number");
            return View();
        }

        // GET: PaymentTransactions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentTransactions = await _context.PaymentTransactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentTransactions == null)
            {
                return NotFound();
            }

            return View(paymentTransactions);
        }

        // GET: PaymentTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,CreatedDate,PaymentDate,Explanation,Explanation2,Explanation3,ContractId,Customer,Cash,CostTypDefenition,IncomeTypeDefenition,TransactionTypDefenition,SupportTypDefenition,Number,CustDocno,SignTypeId,SignTypeDefenition,CashId,TransactionTypeId,CustomersId,CostTypeId,SupportTypeId,ObjectsId,PaymentsId,IncomeTypeId")] PaymentTransactions paymentTransactions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentTransactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentTransactions);
        }

        // GET: PaymentTransactions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentTransactions = await _context.PaymentTransactions.FindAsync(id);
            if (paymentTransactions == null)
            {
                return NotFound();
            }
            return View(paymentTransactions);
        }

        // POST: PaymentTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Amount,CreatedDate,PaymentDate,Explanation,Explanation2,Explanation3,ContractId,Customer,Cash,CostTypDefenition,IncomeTypeDefenition,TransactionTypDefenition,SupportTypDefenition,Number,CustDocno,SignTypeId,SignTypeDefenition,CashId,TransactionTypeId,CustomersId,CostTypeId,SupportTypeId,ObjectsId,PaymentsId,IncomeTypeId")] PaymentTransactions paymentTransactions)
        {
            if (id != paymentTransactions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentTransactions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentTransactionsExists(paymentTransactions.Id))
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
            return View(paymentTransactions);
        }

        // GET: PaymentTransactions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentTransactions = await _context.PaymentTransactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentTransactions == null)
            {
                return NotFound();
            }

            return View(paymentTransactions);
        }

        // POST: PaymentTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var paymentTransactions = await _context.PaymentTransactions.FindAsync(id);
            _context.PaymentTransactions.Remove(paymentTransactions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentTransactionsExists(long id)
        {
            return _context.PaymentTransactions.Any(e => e.Id == id);
        }
    }
}

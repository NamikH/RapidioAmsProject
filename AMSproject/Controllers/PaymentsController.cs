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
    public class PaymentsController : Controller
    {
        private readonly AMSprojectContext _context;

        public PaymentsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var aMSprojectContext = _context.Payments.Include(p => p.Cash).Include(p => p.ContractDetail).Include(p => p.CostType).Include(p => p.IncomeType).Include(p => p.SignType).Include(p => p.TransactionType);
            return View(await aMSprojectContext.ToListAsync());
        }

        public IActionResult CashOperation(int? nt)
        {
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition");
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id");
            ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition");
            //ViewData["CustomersId"] = new SelectList(_context.Customers,"Id","Name");
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Defenition");
            ViewData["CustomersId"] = _context.Customers.Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Name + "   " + a.Surname }).ToList();

            if (nt == 1)
            {
                ViewBag.Error = "<span style=\"color:red !important\">Müştəriyə bağlı xidmət növü mövcud deyil</span><br>";
                return View();
            }
            if (nt == 2)
            {
                ViewBag.Error = "<span style=\"color:red !important\">Kassada kifayət qədər pul yoxdur</span><br>";
            }


            return View();
        }
        public IActionResult PaymentList(int CustomersId)
        {
            var aMSContext = _context.PaymentsList.Where(c => c.CustomersId == CustomersId);


            return View(aMSContext.ToList());
        }

        public ActionResult EditPayment(int id)
        {
            var payments = _context.Payments.Find(id);
            
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition", payments.CashId);
            if (payments.ContractDetailId != null) {
                ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
            }
            if (payments.CostTypeId != null)
            {
                ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition", payments.CostTypeId);
            }
            if (payments.IncomeTypeId != null) 
            {
                ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Defenition", payments.IncomeTypeId);
            }
            ViewData["SignTypeId"] = new SelectList(_context.Set<SignType>(), "Id", "Defenition", payments.SignTypeId);
            ViewData["TransactionTypeId"] = new SelectList(_context.Set<TransactionType>(), "Id", "Defenition", payments.TransactionTypeId);
           
            return PartialView(payments);
        }


        [HttpPost]
        public ActionResult EditPayment([FromBody] Payments[] payments) 
        {
            string result = "Sistem xətası";
            try
            {
                Payments payment = new Payments();
                payment.Id = payments[0].Id;
                payment.Amount = payments[0].Amount;
                payment.Explanation = payments[0].Explanation;
                //payment.Explanation2 = payments[0].Explanation2;
                //payment.Explanation3 = payments[0].Explanation3;
                //payment.TransactionTypeId = payments[0].TransactionTypeId;
                //payment.SignTypeId = payments[0].SignTypeId;
                //payment.CashId = payments[0].CashId;
                //if (payments[0].CostTypeId != null) 
                //{
                //    payment.CostTypeId = payments[0].CostTypeId;
                //}
                //if (payments[0].ContractDetailId != null) 
                //{
                //    payment.ContractDetailId = payments[0].ContractDetailId;
                //}
                //if (payments[0].IncomeTypeId != null) 
                //{
                //    payment.IncomeTypeId = payments[0].IncomeTypeId;
                //}

                _context.Update(payment);
                _context.SaveChanges();

                result = "Əməliyyat uğurla tamamlandı";
            }
            catch (Exception ex) 
            {
                result = ex.Message;
            }

            return Json(result);
        }

        public ActionResult DeletePayment(int id) 
        {
            var payments = _context.Payments.Find(id);

            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition", payments.CashId);
            if (payments.ContractDetailId != null)
            {
                ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
            }
            if (payments.CostTypeId != null)
            {
                ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition", payments.CostTypeId);
            }
            if (payments.IncomeTypeId != null)
            {
                ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Defenition", payments.IncomeTypeId);
            }
            ViewData["SignTypeId"] = new SelectList(_context.Set<SignType>(), "Id", "Defenition", payments.SignTypeId);
            ViewData["TransactionTypeId"] = new SelectList(_context.Set<TransactionType>(), "Id", "Defenition", payments.TransactionTypeId);

            return PartialView(payments);
        }
        [HttpPost]
        public ActionResult DeletePayment([FromBody] Payments[] payment) 
        {
            string result = "Sistem xətası";
            try
            {
                var payments = _context.Payments.Find(payment[0].Id);
                _context.Payments.Remove(payments);
                _context.SaveChanges();

                result = "Əməliyyat uğurla tamamlandı";
            }
            catch (Exception ex) 
            {
                result = ex.Message;
            }
            return Json(result);
        }

        public IActionResult PaymentCreate(int contractdetailid, int customersId, int supporttype)
        {
            var obj = from contract in _context.Contract
                      join contractDetail in _context.ContractDetail
                      on contract.Id equals contractDetail.ContractId
                      join customers in _context.Customers
                      on contract.CustomersId equals customers.Id
                      join supportType in _context.SupportType
                      on contractDetail.SupportTypeId equals supportType.Id
                      where contract.CustomersId == customersId
                      select new
                      {
                          contractDetail.Id,
                          contractDetail.SupportTypeId,
                          contractDetail.ServicePrice,
                          contractDetail.ContractId,
                          supportType.Defenition
                      };

            var list = obj.ToList();

            if (list == null || list.Count == 0)
            {

                return RedirectToAction("CashOperation", "Payments", new { nt = 1 });
            }


            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition");
            ViewData["ContractDetailId"] = new SelectList(list.Where(c => c.SupportTypeId == supporttype), "Id", "Defenition");
            ViewData["SupportTypeId"] = new SelectList(_context.SupportType.Where(c => c.Id == supporttype), "Id", "Defenition");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PaymentCreate([Bind("Id,Amount,Explanation,TransactionTypeId,SignTypeId,CashId,CostTypeId,ContractDetailId")] Payments payments)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    payments.SignTypeId = 1;
                    payments.TransactionTypeId = 1;

                    _context.Add(payments);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(PaymentDetail));
                    return RedirectToAction("PaymentDetail", "Payments", new { Id = payments.Id });
                }
                ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Id", payments.CashId);
                ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
                ViewData["SignTypeId"] = new SelectList(_context.SignType, "Id", "Id", payments.SignTypeId);
                ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "Id", payments.TransactionTypeId);
                //return View(payments);
            }
            catch (Exception ex)
            {

            }
            return View(payments);
        }


        public async Task<IActionResult> PaymentDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.ContractDetail)
                .Include(p => p.ContractDetail.SupportType)
                .Include(p => p.ContractDetail.Contract)
                .Include(p => p.ContractDetail.Contract.Customers)
                .Include(p => p.ContractDetail.Objects)
                .Include(p => p.ContractDetail.Objects.Building)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }


        //Income
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncomeCreate([Bind("Id,Amount,Explanation,TransactionTypeId,SignTypeId,CashId,IncomeTypeId,ContractDetailId,Explanation2,Explanation3")] Payments payments)
        {

            if (ModelState.IsValid)
            //try
            {
                payments.SignTypeId = 1;
                payments.TransactionTypeId = 2;

                _context.Add(payments);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(CostDetail));

                return RedirectToAction("IncomeDetail", "Payments", new { Id = payments.Id });

            }
            //catch (Exception ex) 
            //{
            //    var a = ex.Message;
            //    return View();
            //}
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Id", payments.CashId);
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
            ViewData["SignTypeId"] = new SelectList(_context.SignType, "Id", "Id", payments.SignTypeId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "Id", payments.TransactionTypeId);

            return View("CashOperation");


        }

        public async Task<IActionResult> IncomeDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.Cash)
                .Include(p => p.IncomeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        public IActionResult CostCreate(int? result)
        {

            if (result == 1)
            {
                ViewBag.Error = "<span style=\"color:red !important\">Məxaric üçün kassada kifayət qədər pul yoxdur</span><br>";
            }
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Id");
            ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CostCreate([Bind("Id,Amount,Explanation,TransactionTypeId,SignTypeId,CashId,CostTypeId,ContractDetailId,Explanation2,Explanation3")] Payments payments)
        {
            if (_context.Payments.Include(n => n.Cash).Where(n => n.CashId == payments.CashId).Sum(n => n.Amount) < payments.Amount)
            {
                return RedirectToAction("CashOperation", new { nt = 2 });
            }


            if (ModelState.IsValid)
            {
                payments.SignTypeId = 2;
                payments.TransactionTypeId = 3;

                _context.Add(payments);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(CostDetail));

                return RedirectToAction("CostDetail", "Payments", new { Id = payments.Id });
            }
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Id", payments.CashId);
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
            ViewData["SignTypeId"] = new SelectList(_context.SignType, "Id", "Id", payments.SignTypeId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "Id", payments.TransactionTypeId);
            //return View(payments);

            return View();
        }

        public async Task<IActionResult> CostDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.Cash)
                .Include(p => p.CostType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }


        // GET: Payments/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var payments = await _context.Payments
        //        .Include(p => p.Cash)
        //        .Include(p => p.ContractDetail)
        //        .Include(p => p.CostType)
        //        .Include(p => p.IncomeType)
        //        .Include(p => p.SignType)
        //        .Include(p => p.TransactionType)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (payments == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(payments);
        //}

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition");
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id");
            ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition");
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Defenition");
            ViewData["SignTypeId"] = new SelectList(_context.Set<SignType>(), "Id", "Id");
            ViewData["TransactionTypeId"] = new SelectList(_context.Set<TransactionType>(), "Id", "Id");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Explanation,Explanation2,Explanation3,TransactionTypeId,SignTypeId,CashId,CostTypeId,ContractDetailId,IncomeTypeId")] Payments payments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition", payments.CashId);
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
            ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition", payments.CostTypeId);
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Defenition", payments.IncomeTypeId);
            ViewData["SignTypeId"] = new SelectList(_context.Set<SignType>(), "Id", "Id", payments.SignTypeId);
            ViewData["TransactionTypeId"] = new SelectList(_context.Set<TransactionType>(), "Id", "Id", payments.TransactionTypeId);
            return View(payments);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition", payments.CashId);
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
            ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition", payments.CostTypeId);
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Defenition", payments.IncomeTypeId);
            ViewData["SignTypeId"] = new SelectList(_context.Set<SignType>(), "Id", "Id", payments.SignTypeId);
            ViewData["TransactionTypeId"] = new SelectList(_context.Set<TransactionType>(), "Id", "Id", payments.TransactionTypeId);
            return View(payments);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Explanation,Explanation2,Explanation3,TransactionTypeId,SignTypeId,CashId,CostTypeId,ContractDetailId,IncomeTypeId")] Payments payments)
        {
            if (id != payments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsExists(payments.Id))
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
            ViewData["CashId"] = new SelectList(_context.Cash, "Id", "Defenition", payments.CashId);
            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", payments.ContractDetailId);
            ViewData["CostTypeId"] = new SelectList(_context.CostType, "Id", "Defenition", payments.CostTypeId);
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Defenition", payments.IncomeTypeId);
            ViewData["SignTypeId"] = new SelectList(_context.Set<SignType>(), "Id", "Id", payments.SignTypeId);
            ViewData["TransactionTypeId"] = new SelectList(_context.Set<TransactionType>(), "Id", "Id", payments.TransactionTypeId);
            return View(payments);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.Cash)
                .Include(p => p.ContractDetail)
                .Include(p => p.CostType)
                .Include(p => p.IncomeType)
                .Include(p => p.SignType)
                .Include(p => p.TransactionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payments = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}

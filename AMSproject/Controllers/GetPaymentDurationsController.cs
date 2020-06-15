using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMSproject.Data;
using Microsoft.Data.SqlClient;

namespace AMSproject.Controllers
{
    public class GetPaymentDurationsController : Controller
    {
        private readonly AMSprojectContext _context;

        public GetPaymentDurationsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: GetPaymentDurations
        public async Task<IActionResult> Index()
        {
            var generalTotal = _context.GetPaymentDuration.Sum(a => a.Amount);
            ViewBag.Error = generalTotal.ToString();
            return View(await _context.GetPaymentDuration.ToListAsync());
        }


        public ActionResult NewDuration(int id) 
        {

            ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail.Where(n=>n.Id == id), "Id", "Id");
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewDuration([FromBody] PaymentDuration[] paymentDurations) 
        {
            string result = "Sistem xətası";

            if (_context.PaymentDuration.Where(n => n.ContractDetailId == paymentDurations[0].ContractDetailId).ToList().Count != 0) 
            {
                result = "Bu gecikmə üzrə qeyd mövcuddur";
                return Json(result);
            }
            try
            {
                PaymentDuration paymentDuration = new PaymentDuration();
                paymentDuration.ContractDetailId = paymentDurations[0].ContractDetailId;
                paymentDuration.PaymentDate = paymentDurations[0].PaymentDate;
                paymentDuration.Reason = paymentDurations[0].Reason;
                paymentDuration.CreateDate = DateTime.Now;

                _context.Add(paymentDuration);
                _context.SaveChanges();

                result = "Əməliyyat uğurla tamamlandı";
                return Json(result);
            }
            catch (SqlException ex) 
            {
                result = ex.Message;
                return Json(result);
            }
        }

        public ActionResult EditDuration(int id) 
        {
            try
            {
                var paymentDuration = _context.PaymentDuration.Find(id);

                ViewData["ContractDetailId"] = new SelectList(_context.ContractDetail, "Id", "Id", paymentDuration.ContractDetailId);
                return PartialView();
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Index","GetPaymentDurations");
            }
        }
        [HttpPost]
        public ActionResult EditDuration([FromBody] PaymentDuration[] paymentDurations) 
        {
            string result = "Sistem xətası";
            try
            {
                PaymentDuration paymentDuration = new PaymentDuration();
                paymentDuration.Id = paymentDurations[0].Id;
                paymentDuration.PaymentDate = paymentDurations[0].PaymentDate;
                paymentDuration.Reason = paymentDurations[0].Reason;

                _context.Update(paymentDuration);
                _context.SaveChanges();

                result = "Əməliyyat uğurla tamamlandı";
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return Json(result);
            }
        }


        // GET: GetPaymentDurations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getPaymentDuration = await _context.GetPaymentDuration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getPaymentDuration == null)
            {
                return NotFound();
            }

            return View(getPaymentDuration);
        }

        // GET: GetPaymentDurations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GetPaymentDurations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,CustomersId,ContractDetailId,ContractId,ObjectsId,SupportTypeDefenition,Customer,PaymentDate,Reason,CreateDate,Pdid")] GetPaymentDuration getPaymentDuration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(getPaymentDuration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(getPaymentDuration);
        }

        // GET: GetPaymentDurations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getPaymentDuration = await _context.GetPaymentDuration.FindAsync(id);
            if (getPaymentDuration == null)
            {
                return NotFound();
            }
            return View(getPaymentDuration);
        }

        // POST: GetPaymentDurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Amount,CustomersId,ContractDetailId,ContractId,ObjectsId,SupportTypeDefenition,Customer,PaymentDate,Reason,CreateDate,Pdid")] GetPaymentDuration getPaymentDuration)
        {
            if (id != getPaymentDuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(getPaymentDuration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GetPaymentDurationExists(getPaymentDuration.Id))
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
            return View(getPaymentDuration);
        }

        // GET: GetPaymentDurations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getPaymentDuration = await _context.GetPaymentDuration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getPaymentDuration == null)
            {
                return NotFound();
            }

            return View(getPaymentDuration);
        }

        // POST: GetPaymentDurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var getPaymentDuration = await _context.GetPaymentDuration.FindAsync(id);
            _context.GetPaymentDuration.Remove(getPaymentDuration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GetPaymentDurationExists(long id)
        {
            return _context.GetPaymentDuration.Any(e => e.Id == id);
        }
    }
}

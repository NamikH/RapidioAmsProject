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
    public class CustomersController : Controller
    {
        private readonly AMSprojectContext _context;

        public CustomersController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var aMSprojectContext = _context.Customers.Include(c => c.CustomerType);
            return View(aMSprojectContext.ToList());
        }

        public ActionResult DataTable() 
        { 
            var customers = _context.Customers.Include(c=>c.CustomerType);
            return View(customers.ToList());
        }


        public ActionResult NewCustomer() 
        {

            ViewData["CustomerTypeId"] = new SelectList(_context.Set<CustomerType>(), "Id", "Defenition");
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewCustomer([FromBody] Customers[] customers) 
        {
            if (_context.Customers.Where(
                c=>c.Name == customers[0].Name &&
                c.Surname == customers[0].Surname &&
                c.DocNumber == customers[0].DocNumber &&
                c.Phone == customers[0].Phone).Count() > 0)
            {
                return Json("Bu müştəri artıq mövcuddur");
            }
            string result = "Sistem xətası";
            try
            {
                Customers customer = new Customers();
                customer.Name = customers[0].Name;
                customer.Surname = customers[0].Surname;
                customer.Phone = customers[0].Phone;
                customer.Email = customers[0].Email;
                customer.DocNumber = customers[0].DocNumber;
                customer.CustomerTypeId = customers[0].CustomerTypeId;

                _context.Add(customer);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }

        public ActionResult EditCustomer(int id) 
        {
            var customers =  _context.Customers.Find(id);
            
            ViewData["CustomerTypeId"] = new SelectList(_context.Set<CustomerType>(), "Id", "Defenition", customers.CustomerTypeId);
            return PartialView(customers);
        }

        [HttpPost]
        public ActionResult EditCustomer([FromBody] Customers[] customers) 
        {
            if (_context.Customers.Where(
                c => c.Name == customers[0].Name &&
                c.Surname == customers[0].Surname &&
                c.DocNumber == customers[0].DocNumber &&
                c.Phone == customers[0].Phone).Count() > 0)
            {
                return Json("Bu müştəri artıq mövcuddur");
            }
            string result = "Sistem xətası";
            try
            {
                Customers customer = new Customers();
                customer.Id = customers[0].Id;
                customer.Name = customers[0].Name;
                customer.Surname = customers[0].Surname;
                customer.Phone = customers[0].Phone;
                customer.Email = customers[0].Email;
                customer.DocNumber = customers[0].DocNumber;
                customer.CustomerTypeId = customers[0].CustomerTypeId;

                _context.Update(customer);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }


        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.CustomerType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["CustomerTypeId"] = new SelectList(_context.Set<CustomerType>(), "Id", "Defenition");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Phone,Email,DocNumber,CustomerTypeId,CreatedDate")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerTypeId"] = new SelectList(_context.Set<CustomerType>(), "Id", "Defenition", customers.CustomerTypeId);
            return View(customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            ViewData["CustomerTypeId"] = new SelectList(_context.Set<CustomerType>(), "Id", "Defenition", customers.CustomerTypeId);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Phone,Email,DocNumber,CustomerTypeId,CreatedDate")] Customers customers)
        {
            if (id != customers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.Id))
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
            ViewData["CustomerTypeId"] = new SelectList(_context.Set<CustomerType>(), "Id", "Defenition", customers.CustomerTypeId);
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.CustomerType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMSproject.Data;
using Newtonsoft.Json;

namespace AMSproject.Controllers
{
    public class CustomerTypesController : Controller
    {
        private readonly AMSprojectContext _context;

        public CustomerTypesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: CustomerTypes
        public async Task<IActionResult> Index()
        {
            var customerType = _context.CustomerType.ToList();
            return View(customerType);
        }

        public ActionResult NewCustomerType() 
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewCustomerType([FromBody] CustomerType[] customerTypes) 
        {
            if (_context.CustomerType.Where(d=>d.Defenition == customerTypes[0].Defenition).Count() > 0) 
            {
                return Json("Bu müştəri tipi mövcuddur");
            }
            string result = "Sistem xətası";
            try
            {
                CustomerType customerType = new CustomerType();
                customerType.Defenition = customerTypes[0].Defenition;
                _context.Add(customerType);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }


        public ActionResult EditCustomerType(int id) 
        {
            var customerType = _context.CustomerType.Find(id);
            return PartialView(customerType);
        }

        [HttpPost]
        public ActionResult EditCustomerType([FromBody] CustomerType[] customerTypes) 
        {
            if (_context.CustomerType.Where(d => d.Defenition == customerTypes[0].Defenition).Count() > 0)
            {
                return Json("Bu müştəri tipi mövcuddur");
            }
            string result = "Sistem xətası";

            try
            {
                CustomerType customerType = new CustomerType();
                customerType.Id = customerTypes[0].Id;
                customerType.Defenition = customerTypes[0].Defenition;

                _context.Update(customerType);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }


            return Json(result);
        }



        [HttpGet]
        public JsonResult GetCustomerTypeList()
        {
            return Json(_context.CustomerType.ToList());
        }

        [HttpGet]
        public JsonResult GetCustomerType(int id)
        {
            var objectType = _context.CustomerType.Where(b => b.Id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(objectType, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        public JsonResult SaveDataInDatabase(CustomerType model)
        {
            var result = false;
            try
            {
                if (model.Id > 0)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    result = true;
                }
                else
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result);
        }

        public JsonResult DeleteCustomerTypeRecord(int id)
        {
            bool result = false;

            if (id != 0)
            {
                var objectType = _context.CustomerType.Find(id);
                _context.CustomerType.Remove(objectType);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }


        // GET: CustomerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // GET: CustomerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Defenition")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType.FindAsync(id);
            if (customerType == null)
            {
                return NotFound();
            }
            return View(customerType);
        }

        // POST: CustomerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Defenition")] CustomerType customerType)
        {
            if (id != customerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTypeExists(customerType.Id))
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
            return View(customerType);
        }

        // GET: CustomerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerType = await _context.CustomerType.FindAsync(id);
            _context.CustomerType.Remove(customerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTypeExists(int id)
        {
            return _context.CustomerType.Any(e => e.Id == id);
        }
    }
}

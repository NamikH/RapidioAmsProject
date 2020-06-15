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
using System.Security.Permissions;

namespace AMSproject.Controllers
{
    public class CashesController : Controller
    {
        private readonly AMSprojectContext _context;

        public CashesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: Cashes
        public async Task<IActionResult> Index()
        {
            var cash = _context.Cash.ToList();
            return View(cash);
        }

        public ActionResult NewCash() 
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewCash([FromBody] Cash[] cashes) 
        {
            string result = "Sistem xətası";
            if (_context.Cash.Where(d=>d.Defenition == cashes[0].Defenition && d.Number == cashes[0].Number).Count() > 0) 
            {
                return Json("Bu məlumatlara uyğun kassa mövcuddur");
            }
            try
            {
                Cash cash = new Cash();
                cash.Number = cashes[0].Number;
                cash.Defenition = cashes[0].Defenition;

                _context.Add(cash);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }

        public ActionResult EditCash(int id) 
        {
            var cash = _context.Cash.Find(id);
            return PartialView(cash);
        }

        [HttpPost]
        public ActionResult EditCash([FromBody] Cash[] cashes) 
        {
            if (_context.Cash.Where(d => d.Defenition == cashes[0].Defenition && d.Number == cashes[0].Number).Count() > 0)
            {
                return Json("Bu məlumatlara uyğun kassa mövcuddur");
            }
            if (cashes[0].Number == "" || cashes[0].Defenition == "")
            {
                var cash = _context.Cash.Find(cashes[0].Id);
                return PartialView(cash);
            }
            string result = "Sistem xətası";
            
            try
            {
                Cash cash = new Cash();
                cash.Id = cashes[0].Id;
                cash.Number = cashes[0].Number;
                cash.Defenition = cashes[0].Defenition;

                _context.Update(cash);
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
        public JsonResult GetCashList()
        {
            return Json(_context.Cash.ToList());
        }

        [HttpGet]
        public JsonResult GetCash(int id)
        {
            var objectType = _context.Cash.Where(b => b.Id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(objectType, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        public JsonResult SaveDataInDatabase(Cash model)
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

        public JsonResult DeleteCashRecord(int id)
        {
            bool result = false;

            if (id != 0)
            {
                var objectType = _context.Cash.Find(id);
                _context.Cash.Remove(objectType);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }

        // GET: Cashes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cash = await _context.Cash
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cash == null)
            {
                return NotFound();
            }

            return View(cash);
        }

        // GET: Cashes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cashes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Defenition")] Cash cash)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cash);
        }

        // GET: Cashes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cash = await _context.Cash.FindAsync(id);
            if (cash == null)
            {
                return NotFound();
            }
            return View(cash);
        }

        // POST: Cashes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Defenition")] Cash cash)
        {
            if (id != cash.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashExists(cash.Id))
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
            return View(cash);
        }

        // GET: Cashes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cash = await _context.Cash
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cash == null)
            {
                return NotFound();
            }

            return View(cash);
        }

        // POST: Cashes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cash = await _context.Cash.FindAsync(id);
            _context.Cash.Remove(cash);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashExists(int id)
        {
            return _context.Cash.Any(e => e.Id == id);
        }
    }
}

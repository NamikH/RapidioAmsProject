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
    public class IncomeTypesController : Controller
    {
        private readonly AMSprojectContext _context;

        public IncomeTypesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: IncomeTypes
        public async Task<IActionResult> Index()
        {
            //ViewBag.ListOfIncomeTypes = new SelectList(_context.IncomeType.ToList(),"Id", "Defenition");
            var incomeType = _context.IncomeType.ToList();
            return View(incomeType);
        }


        public ActionResult NewIncomeType()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewIncomeType([FromBody] IncomeType[] incomeTypes) 
        {
            if (_context.IncomeType.Where(i=>i.Defenition == incomeTypes[0].Defenition).Count() > 0) 
            {
                return Json("Bu mədaxil növü mövcuddur");
            }
            string result = "Sistem xətası";
            try
            {
                IncomeType incomeType = new IncomeType();
                incomeType.Defenition = incomeTypes[0].Defenition;
                _context.Add(incomeType);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }

        public ActionResult EditIncomeType(int id) 
        {
            var incomeType = _context.IncomeType.Find(id);
            return PartialView(incomeType);
        
        }


        [HttpPost]
        public ActionResult EditIncomeType([FromBody] IncomeType[] incomeTypes) 
        {
            if (_context.IncomeType.Where(i => i.Defenition == incomeTypes[0].Defenition).Count() > 0)
            {
                return Json("Bu mədaxil növü mövcuddur");
            }
            string result = "Sistem xətası";

            try
            {
                IncomeType incomeType = new IncomeType();
                incomeType.Id = incomeTypes[0].Id;
                incomeType.Defenition = incomeTypes[0].Defenition;

                _context.Update(incomeType);
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
        public JsonResult GetIncomeTypeList() 
        {
            return Json(_context.IncomeType.ToList());
        }
        [HttpGet]
        public JsonResult GetIncomeType(int id) 
        {
            var incomeType = _context.IncomeType.Where(b => b.Id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(incomeType, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }
        public JsonResult SaveDataInDatabase(IncomeType model)
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
        public JsonResult DeleteIncomeTypeRecord(int id)
        {
            bool result = false;

            if (id != 0)
            {
                var incomeType = _context.IncomeType.Find(id);
                _context.IncomeType.Remove(incomeType);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }



        // GET: IncomeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeType = await _context.IncomeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeType == null)
            {
                return NotFound();
            }

            return View(incomeType);
        }

        // GET: IncomeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Defenition")] IncomeType incomeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeType);
        }

        // GET: IncomeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeType = await _context.IncomeType.FindAsync(id);
            if (incomeType == null)
            {
                return NotFound();
            }
            return View(incomeType);
        }

        // POST: IncomeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Defenition")] IncomeType incomeType)
        {
            if (id != incomeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeTypeExists(incomeType.Id))
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
            return View(incomeType);
        }

        // GET: IncomeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeType = await _context.IncomeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeType == null)
            {
                return NotFound();
            }

            return View(incomeType);
        }

        // POST: IncomeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomeType = await _context.IncomeType.FindAsync(id);
            _context.IncomeType.Remove(incomeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeTypeExists(int id)
        {
            return _context.IncomeType.Any(e => e.Id == id);
        }
    }
}

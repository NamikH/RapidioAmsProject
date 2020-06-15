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
    public class CostTypesController : Controller
    {
        private readonly AMSprojectContext _context;

        public CostTypesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: CostTypes
        public async Task<IActionResult> Index()
        {
            //ViewBag.ListOfCostTypes = new SelectList(_context.CostType.ToList(), "Id", "Defenition");
            var costTypes = _context.CostType.ToList();
            return View(costTypes);
        }

        public ActionResult NewCostType()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewCostType([FromBody] CostType[] costTypes)
        {
            if (_context.CostType.Where(c=>c.Defenition == costTypes[0].Defenition).Count() > 0) 
            {
                return Json("Bu məxaric növü mövcuddur");
            }
            string result = "Sistem xətası";
            try
            {
                CostType costType = new CostType();
                costType.Defenition = costTypes[0].Defenition;
                _context.Add(costType);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }

        public ActionResult EditCostType(int id) 
        {
            var costType = _context.CostType.Find(id);

            return PartialView(costType);
        }

        [HttpPost]
        public ActionResult EditCostType([FromBody] CostType[] costTypes) 
        {
            if (_context.CostType.Where(c => c.Defenition == costTypes[0].Defenition).Count() > 0)
            {
                return Json("Bu məxaric növü mövcuddur");
            }
            string result = "Sistem xətası";

            try
            {
                CostType costType = new CostType();
                costType.Id = costTypes[0].Id;
                costType.Defenition = costTypes[0].Defenition;

                _context.Update(costType);
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
        public JsonResult GetCostTypeList()
        {
            return Json(_context.CostType.ToList());
        }

        [HttpGet]
        public JsonResult GetCostType(int id)
        {
            var costType = _context.CostType.Where(b => b.Id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(costType, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        public JsonResult SaveDataInDatabase(CostType model)
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

        public JsonResult DeleteCostTypeRecord(int id)
        {
            bool result = false;

            if (id != 0)
            {
                var costType = _context.CostType.Find(id);
                _context.CostType.Remove(costType);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }

        // GET: CostTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costType = await _context.CostType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costType == null)
            {
                return NotFound();
            }

            return View(costType);
        }

        // GET: CostTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CostTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Defenition")] CostType costType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costType);
        }

        // GET: CostTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costType = await _context.CostType.FindAsync(id);
            if (costType == null)
            {
                return NotFound();
            }
            return View(costType);
        }

        // POST: CostTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Defenition")] CostType costType)
        {
            if (id != costType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostTypeExists(costType.Id))
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
            return View(costType);
        }

        // GET: CostTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costType = await _context.CostType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costType == null)
            {
                return NotFound();
            }

            return View(costType);
        }

        // POST: CostTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costType = await _context.CostType.FindAsync(id);
            _context.CostType.Remove(costType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostTypeExists(int id)
        {
            return _context.CostType.Any(e => e.Id == id);
        }
    }
}

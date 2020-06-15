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
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AMSproject.Controllers
{
    public class SupportTypesController : Controller
    {
        private readonly AMSprojectContext _context;

        public SupportTypesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: SupportTypes
        public async Task<IActionResult> Index()
        {
            var supportType = _context.SupportType.ToList();
            return View(supportType);
        }


        public ActionResult NewSupportType() 
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewSupportType([FromBody] SupportType[] supportTypes) 
        {
            string result = "Sistem xətası";

            try
            {
                SupportType supportType = new SupportType();
                supportType.Defenition = supportTypes[0].Defenition;
                _context.Add(supportType);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex) 
            {
                result = ex.Message;
            }


            return Json(result);
        }


        public ActionResult EditSupportType(int id) 
        {
            var supportType = _context.SupportType.Find(id);
            return PartialView(supportType);
        }
        [HttpPost]
        public ActionResult EditSupportType([FromBody] SupportType[] supportTypes) 
        {
            string result = "Sistem xətası";

            try
            {
                SupportType supportType = new SupportType();
                supportType.Id = supportTypes[0].Id;
                supportType.Defenition = supportTypes[0].Defenition;
                _context.Update(supportType);
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
        public JsonResult GetSupportTypeList()
        {
            return Json(_context.SupportType.ToList());
        }

        [HttpGet]
        public JsonResult GetSupportType(int id)
        {
            var costType = _context.SupportType.Where(b => b.Id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(costType, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        public JsonResult SaveDataInDatabase(SupportType model)
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

        public JsonResult DeleteSupportTypeRecord(int id)
        {
            bool result = false;

            if (id != 0)
            {
                var costType = _context.SupportType.Find(id);
                _context.SupportType.Remove(costType);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }


        // GET: SupportTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportType = await _context.SupportType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportType == null)
            {
                return NotFound();
            }

            return View(supportType);
        }

        // GET: SupportTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Defenition")] SupportType supportType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportType);
        }

        // GET: SupportTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportType = await _context.SupportType.FindAsync(id);
            if (supportType == null)
            {
                return NotFound();
            }
            return View(supportType);
        }

        // POST: SupportTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Defenition")] SupportType supportType)
        {
            if (id != supportType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportTypeExists(supportType.Id))
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
            return View(supportType);
        }

        // GET: SupportTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportType = await _context.SupportType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportType == null)
            {
                return NotFound();
            }

            return View(supportType);
        }

        // POST: SupportTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportType = await _context.SupportType.FindAsync(id);
            _context.SupportType.Remove(supportType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportTypeExists(int id)
        {
            return _context.SupportType.Any(e => e.Id == id);
        }
    }
}

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
    public class ObjectTypesController : Controller
    {
        private readonly AMSprojectContext _context;

        public ObjectTypesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: ObjectTypes
        public async Task<IActionResult> Index()
        {
            var objectType = _context.ObjectType.ToList();
            return View(objectType);
        }

        public ActionResult NewObjectType() 
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewObjectType([FromBody] ObjectType[] objectTypes) 
        {
            if (_context.ObjectType.Where(o=>o.Defenition == objectTypes[0].Defenition).Count() > 0) 
            {
                return Json("Bu obyekt növü mövcuddur");
            }
            string result = "Sistem xətası";
            try
            {
                ObjectType objectType = new ObjectType();
                objectType.Defenition = objectTypes[0].Defenition;
                _context.Add(objectType);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }

        public ActionResult EditObjectType(int id) 
        {
            var objectType = _context.ObjectType.Find(id);
            return PartialView(objectType);
        }

        [HttpPost]
        public ActionResult EditObjectType([FromBody] ObjectType[] objectTypes) 
        {
            if (_context.ObjectType.Where(o => o.Defenition == objectTypes[0].Defenition).Count() > 0)
            {
                return Json("Bu obyekt növü mövcuddur");
            }
            string result = "Sistem xətası";

            try
            {
                ObjectType objectType = new ObjectType();
                objectType.Id = objectTypes[0].Id;
                objectType.Defenition = objectTypes[0].Defenition;

                _context.Update(objectType);
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
        public JsonResult GetObjectTypeList()
        {
            return Json(_context.ObjectType.ToList());
        }

        [HttpGet]
        public JsonResult GetObjectType(int id)
        {
            var objectType = _context.ObjectType.Where(b => b.Id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(objectType, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        public JsonResult SaveDataInDatabase(ObjectType model)
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

        public JsonResult DeleteObjectTypeRecord(int id)
        {
            bool result = false;

            if (id != 0)
            {
                var objectType = _context.ObjectType.Find(id);
                _context.ObjectType.Remove(objectType);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }

        // GET: ObjectTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectType = await _context.ObjectType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objectType == null)
            {
                return NotFound();
            }

            return View(objectType);
        }

        // GET: ObjectTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObjectTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Defenition")] ObjectType objectType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objectType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objectType);
        }

        // GET: ObjectTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectType = await _context.ObjectType.FindAsync(id);
            if (objectType == null)
            {
                return NotFound();
            }
            return View(objectType);
        }

        // POST: ObjectTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Defenition")] ObjectType objectType)
        {
            if (id != objectType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objectType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectTypeExists(objectType.Id))
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
            return View(objectType);
        }

        // GET: ObjectTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectType = await _context.ObjectType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objectType == null)
            {
                return NotFound();
            }

            return View(objectType);
        }

        // POST: ObjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objectType = await _context.ObjectType.FindAsync(id);
            _context.ObjectType.Remove(objectType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectTypeExists(int id)
        {
            return _context.ObjectType.Any(e => e.Id == id);
        }
    }
}

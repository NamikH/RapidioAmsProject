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
    public class ObjectsController : Controller
    {
        private readonly AMSprojectContext _context;

        public ObjectsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: Objects
        public async Task<IActionResult> Index()
        {
            var aMSprojectContext = _context.Objects.Include(o => o.Building).Include(o => o.ObjectType);
            return View(await aMSprojectContext.ToListAsync());
        }


        public ActionResult NewObject() 
        {
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Address");
            ViewData["ObjectTypeId"] = new SelectList(_context.Set<ObjectType>(), "Id", "Defenition");
            return PartialView();
        }


        [HttpPost]
        public ActionResult NewObject([FromBody] Objects[] objects) 
        {
            if (_context.Objects.Where(
                o=>o.BuildingId == objects[0].BuildingId && 
                o.Floor == objects[0].Floor &&
                o.Porch == objects[0].Porch &&
                o.Number == objects[0].Number &&
                o.ObjectTypeId == objects[0].ObjectTypeId).Count() > 0) 
            {
                return Json("Bu obyek artıq mövcuddur");
            }
            string result = "";
            try
            {
                Objects obj = new Objects();
                obj.Porch = objects[0].Porch;
                obj.Floor = objects[0].Floor;
                obj.Number = objects[0].Number;
                obj.Squares = objects[0].Squares;
                obj.BuildingId = objects[0].BuildingId;
                obj.ObjectTypeId = objects[0].ObjectTypeId;

                _context.Add(obj);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }


            return Json(result);
        }

        public ActionResult EditObject(int id) 
        {
            
            var objects =  _context.Objects.Find(id);
            
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Address", objects.BuildingId);
            ViewData["ObjectTypeId"] = new SelectList(_context.Set<ObjectType>(), "Id", "Defenition", objects.ObjectTypeId);
            return PartialView(objects);
        }

        [HttpPost]
        public ActionResult EditObject([FromBody] Objects[] objects) 
        {
            if (_context.Objects.Where(
                o => o.BuildingId == objects[0].BuildingId &&
                o.Floor == objects[0].Floor &&
                o.Porch == objects[0].Porch &&
                o.Number == objects[0].Number &&
                o.ObjectTypeId == objects[0].ObjectTypeId).Count() > 0)
            {
                return Json("Bu obyek artıq mövcuddur");
            }
            string result = "";
            try
            {
                Objects obj = new Objects();
                obj.Porch = objects[0].Porch;
                obj.Floor = objects[0].Floor;
                obj.Number = objects[0].Number;
                obj.Squares = objects[0].Squares;
                obj.BuildingId = objects[0].BuildingId;
                obj.ObjectTypeId = objects[0].ObjectTypeId;

                _context.Update(obj);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }


            return Json(result);
        }



        // GET: Objects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objects = await _context.Objects
                .Include(o => o.Building)
                .Include(o => o.ObjectType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objects == null)
            {
                return NotFound();
            }

            return View(objects);
        }

        // GET: Objects/Create
        public IActionResult Create()
        {
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Address");
            ViewData["ObjectTypeId"] = new SelectList(_context.Set<ObjectType>(), "Id", "Defenition");
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Porch,Floor,Number,Squares,BuildingId,ObjectTypeId")] Objects objects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Address", objects.BuildingId);
            ViewData["ObjectTypeId"] = new SelectList(_context.Set<ObjectType>(), "Id", "Defenition", objects.ObjectTypeId);
            return View(objects);
        }

        // GET: Objects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objects = await _context.Objects.FindAsync(id);
            if (objects == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Address", objects.BuildingId);
            ViewData["ObjectTypeId"] = new SelectList(_context.Set<ObjectType>(), "Id", "Defenition", objects.ObjectTypeId);
            return View(objects);
        }

        // POST: Objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Porch,Floor,Number,Squares,BuildingId,ObjectTypeId")] Objects objects)
        {
            if (id != objects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectsExists(objects.Id))
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
            ViewData["BuildingId"] = new SelectList(_context.Building, "Id", "Address", objects.BuildingId);
            ViewData["ObjectTypeId"] = new SelectList(_context.Set<ObjectType>(), "Id", "Defenition", objects.ObjectTypeId);
            return View(objects);
        }

        // GET: Objects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objects = await _context.Objects
                .Include(o => o.Building)
                .Include(o => o.ObjectType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objects == null)
            {
                return NotFound();
            }

            return View(objects);
        }

        // POST: Objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objects = await _context.Objects.FindAsync(id);
            _context.Objects.Remove(objects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectsExists(int id)
        {
            return _context.Objects.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMSproject.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Windows.Markup;
using Newtonsoft.Json;

namespace AMSproject.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly AMSprojectContext _context;

        public BuildingsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: Buildings
        public IActionResult Index()
        {
            //ViewBag.ListOfDepartment = new SelectList(_context.Building.ToList(), "Id", "Address");

            var building = _context.Building.ToList();
            return View(building);
        }

        public ActionResult NewBuilding() 
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewBuilding([FromBody] Building[] buildings) 
        {
            string result = "Sistem xətası";
            if (_context.Building.Where(n => n.Number == buildings[0].Number && n.Address == buildings[0].Address).Count() > 0) 
            {
                return Json("Bu məlumatlara uyğun bina mövcuddur");
            }
            try
            {
                Building building = new Building();
                building.Number = buildings[0].Number;
                building.Address = buildings[0].Address;

                _context.Add(building);
                _context.SaveChanges();
                result = "Əməliyyat uğurla tamamlandı!";
            }
            catch (Exception ex) 
            {
                result = ex.Message;
            }

            return Json(result);
        }


        public ActionResult EditBuilding(int id) 
        {
            var building =  _context.Building.Find(id);

            return PartialView(building);
        }

        [HttpPost]
        public ActionResult EditBuilding([FromBody] Building[] buildings) 
        {
            string result = "Sistem xətası";
            if (_context.Building.Where(n => n.Number == buildings[0].Number && n.Address == buildings[0].Address).Count() > 0)
            {
                return Json("Bu məlumatlara uyğun bina mövcuddur");
            }
            try
            {
                Building building = new Building();
                building.Id = buildings[0].Id;
                building.Number = buildings[0].Number;
                building.Address = buildings[0].Address;

                _context.Update(building);
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
        public JsonResult GetBuildingList() 
        {    
            return Json(_context.Building.ToList());
        }
        [HttpGet]
        public JsonResult GetBuilding(int id) 
        {
            var buildingList = _context.Building.Where(b => b.Id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(buildingList, Formatting.Indented, new JsonSerializerSettings 
            { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }
        public JsonResult SaveDataInDatabase(Building model)
        {
            var result = false;
            try
            {
                if (model.Id > 0) {
                    _context.Update(model);
                    _context.SaveChanges();
                    result = true;
                }
                else{
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
        public JsonResult DeleteBuildingRecord(int id)
        {
            bool result = false;
            
            if (id != 0)
            {
                var building = _context.Building.Find(id);
                _context.Building.Remove(building);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }




        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Building
                .FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Address")] Building building)
        {
            if (ModelState.IsValid)
            {
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Building.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Address")] Building building)
        {
            if (id != building.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.Id))
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
            return View(building);
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Building
                .FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var building = await _context.Building.FindAsync(id);
            _context.Building.Remove(building);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(int id)
        {
            return _context.Building.Any(e => e.Id == id);
        }
    }
}

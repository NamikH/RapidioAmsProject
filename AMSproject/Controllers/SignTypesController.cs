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
    public class SignTypesController : Controller
    {
        private readonly AMSprojectContext _context;

        public SignTypesController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: SignTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SignType.ToListAsync());
        }

        // GET: SignTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signType = await _context.SignType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signType == null)
            {
                return NotFound();
            }

            return View(signType);
        }

        // GET: SignTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Defenition")] SignType signType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signType);
        }

        // GET: SignTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signType = await _context.SignType.FindAsync(id);
            if (signType == null)
            {
                return NotFound();
            }
            return View(signType);
        }

        // POST: SignTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Defenition")] SignType signType)
        {
            if (id != signType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignTypeExists(signType.Id))
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
            return View(signType);
        }

        // GET: SignTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signType = await _context.SignType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signType == null)
            {
                return NotFound();
            }

            return View(signType);
        }

        // POST: SignTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signType = await _context.SignType.FindAsync(id);
            _context.SignType.Remove(signType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignTypeExists(int id)
        {
            return _context.SignType.Any(e => e.Id == id);
        }
    }
}

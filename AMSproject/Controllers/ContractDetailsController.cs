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
    public class ContractDetailsController : Controller
    {
        private readonly AMSprojectContext _context;

        public ContractDetailsController(AMSprojectContext context)
        {
            _context = context;
        }

        // GET: ContractDetails
        public async Task<IActionResult> Index()
        {
            //var aMSprojectContext = _context.ContractDetail.Include(c => c.Contract).Include(c => c.Objects).Include(c => c.SupportType);
            //return View(await aMSprojectContext.ToListAsync());
            ViewBag.ListOfContracts = _context.ContractDetail.Include(c => c.Contract).Include(c=>c.Contract.Customers).Include(o=>o.Objects);
            return View();


        }

        // GET: ContractDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractDetail = await _context.ContractDetail
                .Include(c => c.Contract)
                .Include(c => c.Objects)
                .Include(c => c.SupportType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractDetail == null)
            {
                return NotFound();
            }

            return View(contractDetail);
        }

        // GET: ContractDetails/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id");
            ViewData["ObjectsId"] = new SelectList(_context.Set<Objects>(), "Id", "Floor");
            ViewData["SupportTypeId"] = new SelectList(_context.Set<SupportType>(), "Id", "Defenition");
            return View();
        }

        // POST: ContractDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractId,SupportTypeId,ServicePrice,ObjectsId")] ContractDetail contractDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id", contractDetail.ContractId);
            ViewData["ObjectsId"] = new SelectList(_context.Set<Objects>(), "Id", "Floor", contractDetail.ObjectsId);
            ViewData["SupportTypeId"] = new SelectList(_context.Set<SupportType>(), "Id", "Defenition", contractDetail.SupportTypeId);
            return View(contractDetail);
        }

        // GET: ContractDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractDetail = await _context.ContractDetail.FindAsync(id);
            if (contractDetail == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id", contractDetail.ContractId);
            ViewData["ObjectsId"] = new SelectList(_context.Set<Objects>(), "Id", "Floor", contractDetail.ObjectsId);
            ViewData["SupportTypeId"] = new SelectList(_context.Set<SupportType>(), "Id", "Defenition", contractDetail.SupportTypeId);
            return View(contractDetail);
        }

        // POST: ContractDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractId,SupportTypeId,ServicePrice,ObjectsId")] ContractDetail contractDetail)
        {
            if (id != contractDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractDetailExists(contractDetail.Id))
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
            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id", contractDetail.ContractId);
            ViewData["ObjectsId"] = new SelectList(_context.Set<Objects>(), "Id", "Floor", contractDetail.ObjectsId);
            ViewData["SupportTypeId"] = new SelectList(_context.Set<SupportType>(), "Id", "Defenition", contractDetail.SupportTypeId);
            return View(contractDetail);
        }

        // GET: ContractDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractDetail = await _context.ContractDetail
                .Include(c => c.Contract)
                .Include(c => c.Objects)
                .Include(c => c.SupportType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractDetail == null)
            {
                return NotFound();
            }

            return View(contractDetail);
        }

        // POST: ContractDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractDetail = await _context.ContractDetail.FindAsync(id);
            _context.ContractDetail.Remove(contractDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractDetailExists(int id)
        {
            return _context.ContractDetail.Any(e => e.Id == id);
        }
    }
}

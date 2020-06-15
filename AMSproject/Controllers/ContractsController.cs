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
using AMSproject.Models;

namespace AMSproject.Controllers
{
    public class ContractsController : Controller
    {
        private readonly AMSprojectContext _context;

        public ContractsController(AMSprojectContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult SaveContract([FromBody] Parameters param)
        {
            string result = "Sistem xətası";
            //if (_context.Contract.Where(c=>c.CustomersId == param.CustomersId).Count() > 1) 
            //{
            //    return Json("Müştərinin müqaviləsi mövcuddur");
            //}
            Contract contract = new Contract();
            contract.CustomersId = param.CustomersId;
            contract.Notes = param.Notes;
            contract.PaymentDate = param.PaymentDate;

            _context.Contract.Add(contract);
            _context.SaveChanges();

            for (int i = 0;i<param.contractDetails.Length; i+=2) 
            {
                //if (_context.ContractDetail.Where(c => c.ObjectsId == param.contractDetails[i].ObjectsId).Count() > 0)
                //{
                //    return Json("Obyekt başqa müqaviləyə bağlıdır");
                //}
                ContractDetail contractDetail = new ContractDetail();
                contractDetail.ContractId = contract.Id;
                contractDetail.SupportTypeId = param.contractDetails[i].SupportTypeId;
                contractDetail.ObjectsId = param.contractDetails[i].ObjectsId;
                contractDetail.ServicePrice = param.contractDetails[i].ServicePrice;
                _context.ContractDetail.Add(contractDetail);
            }

            //foreach (var item in param.contractDetails)
            //{
               
            //}
            _context.SaveChanges();
            result = "Əməliyyat uğurla tamamlandı";

            return Json(result);
        }


        public ActionResult EditContract(int id)
        {
            var contracts = _context.Contract.Find(id);
            ViewData["CustomersId"] = new SelectList(_context.Customers, "Id", "Name", contracts.CustomersId);

            return PartialView(contracts);
        }

        [HttpPost]
        public ActionResult EditContract([FromBody] Contract[] contracts)
        {
            string result = "Error";

            try
            {
                Contract contract = new Contract();
                contract.Id = contracts[0].Id;
                contract.CustomersId = contracts[0].CustomersId;
                contract.Notes = contracts[0].Notes;
                contract.PaymentDate = contracts[0].PaymentDate;
                _context.Update(contract);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }

        public ActionResult EditContractDetail(int Id)
        {
            var detail = _context.ContractDetail.Find(Id);

            ViewData["ContractId"] = new SelectList(_context.Contract, "Id", "Id", detail.ContractId);
            ViewData["ObjectsId"] = new SelectList(_context.Set<Objects>(), "Id", "Floor", detail.ObjectsId);
            ViewData["SupportTypeId"] = new SelectList(_context.Set<SupportType>(), "Id", "Defenition", detail.SupportTypeId);

            return PartialView(detail);

        }

        [HttpPost]
        public ActionResult EditContractDetail([FromBody] ContractDetail[] contractDetails)
        {
            string result = "";

            ContractDetail contractDetail = new ContractDetail();
            contractDetail.Id = contractDetails[0].Id;
            contractDetail.ContractId = contractDetails[0].ContractId;
            contractDetail.ObjectsId = contractDetails[0].ObjectsId;
            contractDetail.ServicePrice = contractDetails[0].ServicePrice;
            contractDetail.SupportTypeId = contractDetails[0].SupportTypeId;
            _context.Update(contractDetail);
            _context.SaveChanges();
            return Json(result);
        }

        public ActionResult AddContractDetail(int id)
        {
            ViewData["ContractId"] = new SelectList(_context.Contract.Where(c=>c.Id == id), "Id", "Id");
            ViewData["ObjectsId"] = new SelectList(_context.Set<Objects>(), "Id", "Floor");
            ViewData["SupportTypeId"] = new SelectList(_context.Set<SupportType>(), "Id", "Defenition");

            return PartialView();
        }

        [HttpPost]
        public ActionResult AddContractDetail([FromBody] ContractDetail[] contractDetails)
        {
            string result = "";

            try
            {
                ContractDetail contractDetail = new ContractDetail();
                contractDetail.ContractId = contractDetails[0].ContractId;
                contractDetail.SupportTypeId = contractDetails[0].SupportTypeId;
                contractDetail.ObjectsId = contractDetails[0].ObjectsId;
                contractDetail.ServicePrice = contractDetails[0].ServicePrice;
                _context.Add(contractDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }

        public ActionResult NewOrder() 
        {
            //ViewBag.Objects = new SelectList(_context.Objects.Include(b=>b.Building).ToList(),"Id","Number");
            ViewData["Objects"] = _context.Objects.OrderBy(n => n.BuildingId).Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = "Bina:" + a.Building.Number + "/" + a.Building.Address + "   " + "Blok:" + a.Porch + " Mərtəbə:" + a.Floor + "  Obyekt№:" + a.Number }).ToList();

            ViewBag.SupportType = new SelectList(_context.SupportType.ToList(),"Id","Defenition");
            ViewBag.Contracts = new SelectList(_context.Customers.ToList(),"Id","Name");
            return PartialView("View");
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            //var aMSprojectContext = _context.Contract.Include(c => c.Customers);
            //return View(await aMSprojectContext.ToListAsync());
            //ViewBag.ListOfContracts = new SelectList(_context.ContractDetail.Include(c => c.Contract).Include(c => c.Contract.Customers).Include(o => o.Objects).ToList(), "Id", "Address");
            //return View();
            var contractDetail = _context.Contract.Include(c => c.Customers).Include(c => c.ContractDetail);
            ViewBag.ListOfObjects = new SelectList(_context.Objects.Include(c=>c.Building).ToList(),"Id","Number");
            ViewBag.ListOfCustomer = new SelectList(_context.Customers.ToList(),"Id","Name");
            ViewBag.ListOfSupportType = new SelectList(_context.SupportType.ToList(), "Id", "Defenition");
            return View(await contractDetail.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["CustomersId"] = new SelectList(_context.Set<Customers>(), "Id", "DocNumber");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomersId,PaymentDate,Notes")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomersId"] = new SelectList(_context.Set<Customers>(), "Id", "DocNumber", contract.CustomersId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["CustomersId"] = new SelectList(_context.Set<Customers>(), "Id", "DocNumber", contract.CustomersId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomersId,PaymentDate,Notes")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
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
            ViewData["CustomersId"] = new SelectList(_context.Set<Customers>(), "Id", "DocNumber", contract.CustomersId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.Id == id);
        }
    }
}

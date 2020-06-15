using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMSproject.Data;
using Microsoft.Data.SqlClient;

namespace AMSproject.Controllers
{
    public class UserPermissionsController : Controller
    {
        private readonly AMSprojectContext _context;

        public UserPermissionsController(AMSprojectContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult SetPermission([FromBody] UserPermissions[] permission)
        {


            var a = permission[0].UserId;
            //string query = $@"UPDATE USERPERMISSIONS SET ACCES = 0 WHERE USERID = {Convert.ToInt32(permission[0].UserId)}";

            SqlTransaction transaction = null;
            var connection = new SqlConnection(CheckPermission.GetConnection());
            connection.Open();

            transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted, "Excell import");
            var command = connection.CreateCommand();
            command.CommandTimeout = 0;
            command.Transaction = transaction;
            command.CommandText = $@"UPDATE USERPERMISSIONS SET ACCES = 0 WHERE USERID = {Convert.ToInt32(permission[0].UserId)}";
            for (int i = 0; i < permission.Count(); i++)
            {
                command.CommandText += $@"UPDATE UserPermissions SET Acces = 1 WHERE Id = {permission[i].Id} AND USERID = {permission[0].UserId}";

            }
            command.ExecuteNonQuery();
            transaction.Commit();

            return View();
        }

        // GET: UserPermissions/Create
        [HttpGet]
        public IActionResult Create(int Id)
        {

            ViewData["UserId"] = new SelectList(_context.Users.Where(u => u.Id == Id), "Id", "Username");
            var itemList1 = _context.UserPermissions.Where(u => u.Permission.Number.Length == 1).Include(p => p.Permission).Include(u => u.User).Where(u => u.User.Id == Id);
            var itemList2 = _context.UserPermissions.Where(u => u.Permission.Number.Length == 3).Include(p => p.Permission).Include(u => u.User).Where(u => u.User.Id == Id);
            var itemList3 = _context.UserPermissions.Where(u => u.Permission.Number.Length == 5).Include(p => p.Permission).Include(u => u.User).Where(u => u.User.Id == Id);
            var itemList4 = _context.UserPermissions.Where(u => u.Permission.Number.Length == 7).Include(p => p.Permission).Include(u => u.User).Where(u => u.User.Id == Id);
            ViewBag.ItemList = itemList1;
            ViewBag.ItemList2 = itemList2;
            ViewBag.ItemList3 = itemList3;
            ViewBag.ItemList4 = itemList4;
            //var itemList = _context.UserPermissions.Where(u=>u.UserId==Id).Include(p => p.Permission).Include(u => u.User).Where(u => u.User.Id == Id);
            //ViewBag.ItemList = itemList;
            return View();
        }


        // GET: UserPermissions
        public async Task<IActionResult> Index()
        {
            var aMSprojectContext = _context.UserPermissions.Include(u => u.Permission).Include(u => u.User);
            return View(await aMSprojectContext.ToListAsync());
        }

        // GET: UserPermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPermissions = await _context.UserPermissions
                .Include(u => u.Permission)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPermissions == null)
            {
                return NotFound();
            }

            return View(userPermissions);
        }

        // GET: UserPermissions/Create
        public IActionResult Create()
        {
            ViewData["PermissionId"] = new SelectList(_context.Permission, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "Id", "Password");
            return View();
        }

        // POST: UserPermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PermissionId,Acces")] UserPermissions userPermissions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPermissions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermissionId"] = new SelectList(_context.Permission, "Id", "Id", userPermissions.PermissionId);
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "Id", "Password", userPermissions.UserId);
            return View(userPermissions);
        }

        // GET: UserPermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPermissions = await _context.UserPermissions.FindAsync(id);
            if (userPermissions == null)
            {
                return NotFound();
            }
            ViewData["PermissionId"] = new SelectList(_context.Permission, "Id", "Id", userPermissions.PermissionId);
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "Id", "Password", userPermissions.UserId);
            return View(userPermissions);
        }

        // POST: UserPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PermissionId,Acces")] UserPermissions userPermissions)
        {
            if (id != userPermissions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPermissions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPermissionsExists(userPermissions.Id))
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
            ViewData["PermissionId"] = new SelectList(_context.Permission, "Id", "Id", userPermissions.PermissionId);
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "Id", "Password", userPermissions.UserId);
            return View(userPermissions);
        }

        // GET: UserPermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPermissions = await _context.UserPermissions
                .Include(u => u.Permission)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPermissions == null)
            {
                return NotFound();
            }

            return View(userPermissions);
        }

        // POST: UserPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPermissions = await _context.UserPermissions.FindAsync(id);
            _context.UserPermissions.Remove(userPermissions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPermissionsExists(int id)
        {
            return _context.UserPermissions.Any(e => e.Id == id);
        }
    }
}

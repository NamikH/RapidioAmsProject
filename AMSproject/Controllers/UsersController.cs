using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMSproject.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace AMSproject.Controllers
{
    public class UsersController : Controller
    {
        private readonly AMSprojectContext _context;

        public UsersController(AMSprojectContext context)
        {
            _context = context;
        }

        public IActionResult Login() 
        {
            return View();
        }


        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_context.Users.Where(n => n.Username == username && n.Password == Encrypt(password)).Count() > 0)
            {
                var id = _context.Users.Where(u => u.Username == username && u.Password == Encrypt(password)).Select(u => u.Id).First();

                HttpContext.Session.SetString("_User", id.ToString());

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "<span style=\"color:red !important\">Istifadəçi adı və ya şifrə yalnışdır</span><br>";
                return View("Login");
            }
        }
        public IActionResult Exit()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login","Users");
        }
        public ActionResult NewUser() 
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult NewUser([FromBody] Users[] users) 
        {
            string result = "Sistem xətası";
            if (_context.Users.Where(n => n.Username == users[0].Username).Count() > 0)
            {
                result = "Daxil etdiyiniz istifadəçi adı artıq mövcuddur";
                return Json(result);
            }

            else
            {
                try
                {
                    Users user = new Users();
                    user.Username = users[0].Username;
                    user.Password = Encrypt(users[0].Password.ToString());
                    user.IsAdmin = users[0].IsAdmin;

                    _context.Add(user);
                    _context.SaveChanges();

                    var query = "select * from permission";
                    //var connectionString = "Server=Namik;Database=AMSDBSECOND;Trusted_Connection=true;MultipleActiveResultSets=true";

                    DataTable dt;

                    SqlConnection con = new SqlConnection(CheckPermission.GetConnection());
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    var a = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(a);
                    con.Close();

                    SqlCommand cmd2 = new SqlCommand(query, con);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var c = dt.Rows[i]["Id"];
                    }
                    SqlTransaction transaction = null;
                    var connection = new SqlConnection(CheckPermission.GetConnection());
                    connection.Open();

                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted, "Excell import");
                    var command = connection.CreateCommand();
                    command.CommandTimeout = 0;
                    command.Transaction = transaction;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        command.CommandText += $@"insert into UserPermissions(UserId,PermissionId,Acces) values ({user.Id},{dt.Rows[i]["Id"]},0)";
                    }
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    result = "Əməliyyat uğurla tamamlandı";

                    return Json(result);
                }
                catch (Exception ex)
                {
                    result = ex.Message;

                    return Json(result);
                }
            }
        }

        public ActionResult EditUser(int id) 
        {
            var users = _context.Users.Find(id);

            return PartialView(users);
        
        }

        [HttpPost]
        public ActionResult EditUser([FromBody] Users[] users) 
        {
            string result = "Sistem xətası";
            try
            {
                

                Users user = new Users();
                user.Id = users[0].Id;
                user.Username = users[0].Username;
                if (_context.Users.Where(n => n.Id == users[0].Id && n.Password == users[0].Password).Count() > 0)
                {
                    user.Password = users[0].Password;
                }
                else 
                {
                    user.Password = Encrypt(users[0].Password.ToString());
                }
                user.IsAdmin = users[0].IsAdmin;

                _context.Update(user);
                _context.SaveChanges();
                result = "Əməliyyat yğurla tamamlandı";
            }
            catch (Exception ex) 
            {
                result = ex.Message;
            }
            return Json(result);
        }


        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,IsAdmin")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,IsAdmin")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
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
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

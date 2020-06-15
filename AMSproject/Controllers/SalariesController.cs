using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMSproject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using System.Data;
using FastMember;
using OfficeOpenXml;
using ExcelDataReader;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AMSproject.Controllers
{
    public class Employee
    {
        public string Amount { get; set; }
        public string TransactionType { get; set; }
        public string SignTypes { get; set; }
        public string Cashes { get; set; }
        public string ContractDetails { get; set; }
        public string Persons { get; set; }
    }
    public class SalariesController : Controller
    {
        private readonly AMSprojectContext _context;

        private readonly IHostingEnvironment _host;

        public SalariesController(AMSprojectContext context,IHostingEnvironment hosting)
        {
            _context = context;
            _host = hosting;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salary.ToListAsync());
        }

        public IActionResult Download()
        {
            List<Employee> employees = new List<Employee>();
            string query = $@"SELECT '' AS Məbləğ,'4' AS HərəkətTipi,'2' AS ƏməliyyatNövü,'3' AS Kassa,ContractDetail.Id AS Xidmət,Customers.Name+' '+Customers.Surname as İşçi FROM Customers 
                              INNER JOIN Contract ON Contract.CustomersId = Customers.Id 
                              INNER JOIN ContractDetail ON ContractDetail.ContractId = Contract.Id";
                              //WHERE Customers.CustomerTypeId = 2004";

            SqlConnection con = new SqlConnection(CheckPermission.GetConnection());
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                employees.Add(new Employee
                {
                    Amount = dr.GetValue(0).ToString(),
                    TransactionType = dr.GetValue(1).ToString(),
                    SignTypes = dr.GetValue(2).ToString(),
                    Cashes = dr.GetValue(3).ToString(),
                    ContractDetails = dr.GetValue(4).ToString(),
                    Persons = dr.GetValue(5).ToString()
                });
            }

            DataTable dt = new DataTable();
            using (var reader = ObjectReader.Create(employees))
            {
                dt.Load(reader);
            }

            byte[] fileContents;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("employees");
                worksheet.Cells["A1"].LoadFromDataTable(dt, true);
                fileContents = package.GetAsByteArray();
            }




            con.Close();

            return File(fileContents: fileContents,
                 contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                 fileDownloadName: "Şablon(Əmək haqqı).xlsx");
        }

        public async Task<IActionResult> SalaryImport()
        {
            return View();
        }

        public async Task<IActionResult> Import(IFormFile excelFile)
        {
            if (excelFile == null)
            {
                ViewBag.Error = "<span style=\"color:red !important\">Fayl seçilməyib</span><br>";
                return View("SalaryImport");
            }

            if (excelFile.Length == 0)
            {
                ViewBag.Error = "<span style=\"color:red !important\">Seçilmiş faylda sətir yoxdur</span><br>";
                return View("SalaryImport");
            }
            if (excelFile.FileName.EndsWith("xls") || excelFile.FileName.EndsWith("xlsx"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                try
                {
                    string path = "/Files/" + excelFile.FileName;

                    using (var fileStream = new FileStream(_host.WebRootPath + path, FileMode.Create))
                    {
                        await excelFile.CopyToAsync(fileStream);
                    }

                    List<Payments> users = new List<Payments>();
                    ViewBag.users = users;
                    var pathh = "/Files/" + excelFile.FileName;


                    using (var stream = System.IO.File.Open(_host.WebRootPath + pathh, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            //for (int i = 1;i<=reader.RowCount; i++) 
                            //{
                            //    users.Add(new Payments
                            //    {
                            //        Amount = Convert.ToDecimal(reader.GetValue(0)),
                            //        CashId = Convert.ToInt32(reader.GetValue(1)),
                            //        ContractDetailId = Convert.ToInt32(reader.GetValue(2)),
                            //        SignTypeId = Convert.ToInt32(reader.GetValue(3)),
                            //        TransactionTypeId = Convert.ToInt32(reader.GetValue(4))
                            //    });
                            //}

                            while (reader.Read()) //Each row of the file
                            {
                                if (reader.GetValue(3).ToString() != "Persons")
                                {
                                    if (Convert.ToDecimal(reader.GetValue(0)) > 0)
                                    {

                                        users.Add(new Payments
                                        {
                                            Amount = Convert.ToDecimal(reader.GetValue(0)),
                                            CashId = Convert.ToInt32(reader.GetValue(1)),
                                            ContractDetailId = Convert.ToInt32(reader.GetValue(2)),
                                            SignTypeId = Convert.ToInt32(reader.GetValue(4)),
                                            TransactionTypeId = Convert.ToInt32(reader.GetValue(5))
                                        });

                                    }
                                }
                            }

                        }

                    }
                    //SqlConnection con = new SqlConnection($@"Data Source=Namik;Initial Catalog=userdb;User Id=NAMIK;Integrated Security=true");
                    SqlTransaction transaction = null;
                    var connection = new SqlConnection(CheckPermission.GetConnection());
                    connection.Open();

                    transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted, "Excell import");
                    var command = connection.CreateCommand();
                    command.CommandTimeout = 0;
                    command.Transaction = transaction;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (Convert.ToDecimal(users[i].Amount) > 0)
                        {
                            command.CommandText += $@"insert into payments(amount,cashid,contractdetailid,signtypeid,transactiontypeid) 
                                        values({Convert.ToDecimal(users[i].Amount)},
                                               {Convert.ToInt32(users[i].CashId)},
                                               {Convert.ToInt32(users[i].ContractDetailId)},
                                               {Convert.ToInt32(users[i].SignTypeId)},
                                               { Convert.ToInt32(users[i].TransactionTypeId)})";
                        }
                    }

                    System.IO.File.Delete(_host.WebRootPath + pathh);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return View("SalaryImportViewData");

                }
                catch (Exception ex)
                {
                    ViewBag.Error = $@"{ex.Message} + <br>";
                    return View("SalaryImport");
                }
            }
            else
            {
                ViewBag.Error = "<span style=\"color:red !important\">Fayl excel formatında olmalıdır</span><br>";
                return View("SalaryImport");
            }

        }

        public IActionResult Indexes()
        {

            return View();
        }
        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Explanation")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Explanation")] Salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.Id))
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
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salary = await _context.Salary.FindAsync(id);
            _context.Salary.Remove(salary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(int id)
        {
            return _context.Salary.Any(e => e.Id == id);
        }
    }
}

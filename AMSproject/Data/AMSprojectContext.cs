using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AMS.Models;

namespace AMSproject.Data
{
    public class AMSprojectContext : DbContext
    {
        public AMSprojectContext (DbContextOptions<AMSprojectContext> options)
            : base(options)
        {
        }

        public DbSet<AMS.Models.Building> Building { get; set; }

        public DbSet<AMS.Models.Cash> Cash { get; set; }

        public DbSet<AMS.Models.CashBalance> CashBalance { get; set; }

        public DbSet<AMS.Models.Contract> Contract { get; set; }

        public DbSet<AMS.Models.ContractDetail> ContractDetail { get; set; }

        public DbSet<AMS.Models.CostType> CostType { get; set; }

        public DbSet<AMS.Models.Customers> Customers { get; set; }

        public DbSet<AMS.Models.CustomerType> CustomerType { get; set; }

        public DbSet<AMS.Models.GetPaymentDuration> GetPaymentDuration { get; set; }

        public DbSet<AMS.Models.IncomeType> IncomeType { get; set; }

        public DbSet<AMS.Models.Objects> Objects { get; set; }

        public DbSet<AMS.Models.ObjectType> ObjectType { get; set; }

        public DbSet<AMS.Models.PaymentDuration> PaymentDuration { get; set; }

        public DbSet<AMS.Models.Payments> Payments { get; set; }

        public DbSet<AMS.Models.PaymentsList> PaymentsList { get; set; }

        public DbSet<AMS.Models.PaymentTransactions> PaymentTransactions { get; set; }

        public DbSet<AMS.Models.Permission> Permission { get; set; }

        public DbSet<AMS.Models.Salary> Salary { get; set; }

        public DbSet<AMS.Models.SignType> SignType { get; set; }

        public DbSet<AMS.Models.SupportType> SupportType { get; set; }

        public DbSet<AMS.Models.TransactionType> TransactionType { get; set; }

        public DbSet<AMS.Models.UserPermissions> UserPermissions { get; set; }

        public DbSet<AMS.Models.Users> Users { get; set; }
    }
}

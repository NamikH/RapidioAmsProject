using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class CashBalance
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public int CashId { get; set; }
        public string Number { get; set; }
        public string Defenition { get; set; }
    }
}

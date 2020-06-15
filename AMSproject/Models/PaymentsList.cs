using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class PaymentsList
    {
        public long Id { get; set; }
        public int ContractDetailId { get; set; }
        public int SupportTypeId { get; set; }
        public int ObjectsId { get; set; }
        public decimal Amount { get; set; }
        public string SpDefenition { get; set; }
        public string ObjNumber { get; set; }
        public int CustomersId { get; set; }
        public decimal MonthDept { get; set; }
    }
}

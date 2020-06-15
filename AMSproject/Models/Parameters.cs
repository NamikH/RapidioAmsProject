using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSproject.Models
{
    public class Parameters
    {
        public int CustomersId { get; set; }
        public string Notes { get; set; }
        public DateTime PaymentDate { get; set; }

        public ContractDetail[] contractDetails { get; set; }
    }
}

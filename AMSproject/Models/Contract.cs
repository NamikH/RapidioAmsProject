using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }
        
        public Customers Customers { get; set; }

        public ICollection<ContractDetail> ContractDetail { get; set; }
        
    }
}

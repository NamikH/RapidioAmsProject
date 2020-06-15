using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class PaymentDuration
    {
        public int Id { get; set; }
        public int ContractDetailId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PaymentDate { get; set; }
        public string Reason { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? CreateDate { get; set; }

        public ContractDetail Contract { get; set; }
    }
}

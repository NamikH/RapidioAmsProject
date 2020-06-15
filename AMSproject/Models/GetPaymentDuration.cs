using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class GetPaymentDuration
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public int CustomersId { get; set; }
        public int ContractDetailId { get; set; }
        public int ContractId { get; set; }
        public int ObjectsId { get; set; }
        public string SupportTypeDefenition { get; set; }
        public string Customer { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? PaymentDate { get; set; }
        public string Reason { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? CreateDate { get; set; }
        public int? Pdid { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class PaymentTransactions
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreatedDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Explanation { get; set; }
        public string Explanation2 { get; set; }
        public string Explanation3 { get; set; }
        public int? ContractId { get; set; }
        public string Customer { get; set; }
        public string Cash { get; set; }
        public string CostTypDefenition { get; set; }
        public string IncomeTypeDefenition { get; set; }
        public string TransactionTypDefenition { get; set; }
        public string SupportTypDefenition { get; set; }
        public string Number { get; set; }
        public string CustDocno { get; set; }

        public int SignTypeId { get; set; }
        public string SignTypeDefenition { get; set; }

        public int? CashId { get; set; }
        public int? TransactionTypeId { get; set; }
        public int? CustomersId { get; set; }
        public int? CostTypeId { get; set; }
        public int? SupportTypeId { get; set; }
        public int? ObjectsId { get; set; }
        public int? PaymentsId { get; set; }
        public int? IncomeTypeId{get;set;}
    }
}

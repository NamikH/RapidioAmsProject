using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        
        public string Explanation { get; set; }
        
        public string Explanation2 { get; set; }
        
        public string Explanation3 { get; set; }
       public int TransactionTypeId { get; set; }
       public int SignTypeId { get; set; }
       public int CashId { get; set; }
       public int? CostTypeId { get; set; }
       public int? ContractDetailId { get; set; }
       public int? IncomeTypeId { get; set; }
       public TransactionType TransactionType { get; set; }
       public SignType SignType { get; set; }
       public Cash Cash { get; set; }
       public ContractDetail ContractDetail { get; set; }
       public CostType CostType { get; set; }
       public IncomeType IncomeType { get; set; }
    }
}

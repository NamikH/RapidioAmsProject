using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class ContractDetail
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int SupportTypeId { get; set; }
        public decimal ServicePrice { get; set; }
        public int ObjectsId { get; set; }

        public Contract Contract { get; set; }
        public SupportType SupportType { get; set; }
        [AllowNull]
        public Objects Objects { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public ICollection<PaymentDuration> PaymentDuration { get; set; }
        
    }
}

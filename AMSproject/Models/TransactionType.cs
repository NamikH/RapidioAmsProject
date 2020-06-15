using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Defenition { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}

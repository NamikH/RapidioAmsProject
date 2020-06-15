using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class Cash
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Defenition { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}

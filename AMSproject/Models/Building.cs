using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class Building
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<Objects> Objects { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DocNumber { get; set; }
        [Required]
        public int CustomerTypeId {get;set;}

        
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        //public DateTime CreatedDate { get; set; }



        public CustomerType CustomerType { get; set; }

        public ICollection<Contract> Contract { get; set; }
        
    }
}

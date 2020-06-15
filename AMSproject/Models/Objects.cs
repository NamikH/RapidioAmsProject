using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class Objects
    {
        public int Id { get; set; }
        [Required]
        public string Porch { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public decimal Squares { get; set; }
        public int BuildingId { get; set; }
        [Required]
        public int ObjectTypeId { get; set; }

        public Building Building { get; set; }
        public ObjectType ObjectType { get; set; }
        public ICollection<ContractDetail> ContractDetail { get; set; }
    }
}

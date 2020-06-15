﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class CustomerType
    {
        public int Id { get; set; }
        [Required]
        public string Defenition { get; set; }

        public ICollection<Customers> Customers { get;set; }
    }
}

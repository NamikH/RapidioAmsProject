using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Defenition { get; set; }

        public string Number { get; set; }

        public ICollection<UserPermissions> UserPermissions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.user
{
    public enum RoleType : int
    {
        admin = 1,
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleType Type => (RoleType)Id;
    }

}

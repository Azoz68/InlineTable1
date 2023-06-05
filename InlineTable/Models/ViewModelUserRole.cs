using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InlineTable.Models
{
    public class ViewModelUserRole
    {
        public Users User { get; set; }
        public IEnumerable<Roles> Role { get; set; }
    }
}
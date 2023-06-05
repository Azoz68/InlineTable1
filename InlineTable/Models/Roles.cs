using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InlineTable.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Deleted { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InlineTable.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public List<Roles> Role { get; set; }
    }
}
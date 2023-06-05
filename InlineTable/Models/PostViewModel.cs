using InlineTable.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InlineTable.Models
{
    public class PostViewModel
    {
        public Post posts { get; set; }
        public IEnumerable<Auther> authers { get; set; }
    }
}
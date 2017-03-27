using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBlog.Models
{

    public class PageCategory
    {
        public int ID { get; set; }
        public int PageID { get; set; }
        public int CategoryID { get; set; }

        public virtual Page Page {get; set;}
        public virtual Category Category { get; set; }
    }
}
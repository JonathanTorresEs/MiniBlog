using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MiniBlog.Models
{
    public class Category
    {

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title must not exceed 50 characters.")]
        public string Name { get; set; }

        public virtual ICollection<PageCategory> PageCategory { get; set; }


    }
}
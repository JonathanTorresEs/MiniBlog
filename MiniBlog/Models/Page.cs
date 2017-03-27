using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniBlog.Models
{

    public enum Cat
    {
        PvP, Skilling, PvM, General
    }

    public class Page
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Title must not exceed 255 characters.")]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

       public virtual ICollection<PageCategory> PageCategory { get; set; }
    }
}
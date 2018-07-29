using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class LibraryBranch
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; } 

        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime openDate { get; set; }
    }
}

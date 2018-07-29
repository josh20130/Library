using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public abstract class LibraryAsset
    {
        public int ID { get; set; } 

        [Required]
        public string Title { get; set;}    

        [Required]
        public int Year { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string imageURL { get; set; }

        public int numberOfCopies { get; set; }

        public virtual LibraryBranch Location { get; set; }
    }
}

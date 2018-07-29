using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class Checkout
    {
        public int ID { get; set; } 

        [Required]
        public LibraryAsset libraryAsset { get; set; }  
        public LibraryCard LibraryCard { get; set; }
        public DateTime Since { get; set; } 
        public DateTime Until { get; set; }
    }
}

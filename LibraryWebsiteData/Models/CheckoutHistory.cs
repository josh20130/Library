using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class CheckoutHistory
    {
        public int ID { get; set; } 

        [Required]
        public LibraryAsset LibraryAsset { get; set; }  

        [Required]
        public LibraryCard LibraryCard { get; set; }

        [Required]
        public DateTime CheckedOut { get; set; }    

        public DateTime? CheckedIn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class Status
    {
        public int ID { get; set; } 

        [Required]
        public string Name { get; set; }    

        [Required]
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class BranchHours
    {
        public int ID { get; set; }
        public LibraryBranch Branch { get; set; }   

        [Range(0, 6)]
        public int dayOfWeek { get; set; }

        [Range(0, 23)]
        public int openTime { get; set; }   

        [Range(0, 23)]
        public int closeTime { get; set; }  
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class Patron
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; } 
        public DateTime dateOfBirth { get; set; }
        public string telephoneNumber { get; set; }

        public virtual LibraryCard libraryCard { get; set; }
        public virtual LibraryBranch homeLibraryBranch { get; set; }
    }
}

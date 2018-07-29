using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class Holds
    {
        public int ID { get; set; }
        public virtual LibraryAsset LibraryAsset { get; set; }
        public virtual LibraryCard LibraryCarrd { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}

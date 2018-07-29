using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebsiteData.Models
{
    public class LibraryCard
    {
        public int ID { get; set; }

        public decimal Fees { get; set; }

        public DateTime Created { get; set; }

        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}

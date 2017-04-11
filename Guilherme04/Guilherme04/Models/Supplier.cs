using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guilherme04.Models
{
    public class Supplier
    {
        public long? SupplierID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
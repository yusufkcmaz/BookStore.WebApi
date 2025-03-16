using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public string ProductAbout { get; set; }
        public decimal ProductPrice { get; set; }
        public string Writer { get; set; }

    }
}

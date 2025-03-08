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
        public string ImageUrl  { get; set; }
        public string BookName  { get; set; }
        public string Description   { get; set; }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        //Bir yazarın birden fazla kitabı olabilir.
        public virtual List<Product>? Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Footer
    {
        public int FooterId { get; set; }
        public string Description { get; set; }
        public string ?Description1 { get; set; }
        public string  BooksawLocal { get; set; }
        public string  PhoneNumber { get; set; }
        public string  Email { get; set; }
        public string ?FacebookUrl { get; set; }
        public string ?TwitterUrl { get; set; }
        public string ?InstagramUrl { get; set; }
        public string ?LinkedinUrl { get; set; }
    }
}

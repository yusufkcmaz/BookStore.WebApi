﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }
        public string  Mail { get; set; }
        public DateTime SubcribeDate  { get; set; } = DateTime.Now; //->Default tarih atama 
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public string WriterQuote { get; set; }
        public string Quotedtext { get; set; }
    }
}

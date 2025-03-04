﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlavCrypto.Models
{
    public class Cryptocurrency
    {
        public int CryptocurrencyId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double Price { get; set; }
        public DateTime PriceUpdateDate { get; set; }
    }
}

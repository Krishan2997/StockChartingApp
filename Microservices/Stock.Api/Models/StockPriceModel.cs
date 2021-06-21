using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.Models
{
    public class StockPriceModel
    {
        public int StockExchangeId { get; set; }

        public int CompanyStockCode { get; set; }


        public float CurrentPrice { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

    }
}

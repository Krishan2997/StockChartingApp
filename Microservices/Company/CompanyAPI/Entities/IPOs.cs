using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Entities
{
    public enum Type
    {
        first,
        second
    }
    public class IPOs
    {
        public int Id { get; set; }
        public Type Abc { get; set; }
        public int CompanyId { get; set; }
        public Companies Company { get; set; }
        
        public List<StockExchanges> StockExchanges { get; set; }
        public long PricePerShare { get; set; }
        public long TotalNumberOfShares { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime OpenDate { get; set; }
        public string Remark { get; set; }

    }
}
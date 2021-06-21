using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Entities
{
    public class StockExchanges
    {

        [Key]
        public int Id { get; set; }

        public string StockExchangeName { get; set; }
        public string Brief { get; set; }
        public Address ContactAddress { get; set; }
        public string Remark { get; set; }

        public int IPOsId { get; set; }
        public IPOs IPOs { get; set; }

    }


    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostalCode { get; set; }

    }
}

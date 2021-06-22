using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Entities
{
    public class Companies
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Turnover { get; set; }
        public string Ceo { get; set; }
        public string Sector { get; set; }
        public string Brief { get; set; }
        public int StockCode { get; set; }

        //public IPOs IPOs { get; set; }

    }
}
#region usings
using System.Collections.Generic;
using System.Linq;
#endregion usings

namespace DataAnalysis.Domain.Models
{
    public class Sale
    {
        public Sale()
        {
            SaleItem = new List<SaleItem>();
        }
        public string SaleId { get; set; }
        public string SalesmanName { get; set; }
        public List<SaleItem> SaleItem { get; set; }
        public decimal TotalSale { get { return SaleItem.Sum(x => x.Quantity * x.Price); } }

    }
}


#region usings
using DataAnalysis.Domain.Models;
using System.Collections.Generic;
#endregion usings

namespace DataAnalysis.Domain.Interfaces
{
    public interface ISaleService
    {
        Sale CreateObject(string line);
        List<Sale> GetListSale(string file);
        string GetBiggestSale(List<Sale> sales);
        string GetWorstSeller(List<Sale> sales);
    }
}

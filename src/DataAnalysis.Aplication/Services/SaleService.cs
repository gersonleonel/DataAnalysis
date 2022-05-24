#region usings
using DataAnalysis.Domain.Interfaces;
using DataAnalysis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
#endregion usings

namespace DataAnalysis.Aplication.Services
{
    public class SaleService : ISaleService
    {
        public Sale CreateObject(string line)
        {
            var splitedData = line.Split("ç");

            return new Sale
            {
                SaleId = splitedData[1],
                SaleItem = CreateObjectItem(splitedData[2]),
                SalesmanName = splitedData[3]
            };
        }

        private List<SaleItem> CreateObjectItem(string itens)
        {
            var splitedData = string.Join("", itens.Split('[', ']')).Split(',');
            return splitedData.Select(x => new SaleItem
            {
                ItemId = Convert.ToInt32(x.Split('-')[0]),
                Quantity = Convert.ToInt32(x.Split('-')[1]),
                Price = decimal.Parse(x.Split('-')[2], CultureInfo.InvariantCulture)
            }).ToList();
        }

        public List<Sale> GetListSale(string file)
        {
            List<Sale> listSales = new();

            var lines = File.ReadAllLines(file);

            foreach (var line in lines.Where(x => x.StartsWith("003")).ToArray())
                listSales.Add(CreateObject(line));

            return listSales;
        }

        public string GetBiggestSale(List<Sale> sales)
        {
            return sales.OrderByDescending(x => x.TotalSale).FirstOrDefault().SaleId;
        }

        public string GetWorstSeller(List<Sale> sales)
        {
            return sales.OrderBy(x => x.TotalSale).FirstOrDefault().SalesmanName;
        }
    }
}

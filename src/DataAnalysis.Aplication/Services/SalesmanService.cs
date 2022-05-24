#region usings
using DataAnalysis.Domain.Interfaces;
using DataAnalysis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion usings

namespace DataAnalysis.Aplication.Services
{
    public class SalesmanService : ISalesmanService
    {
        public Salesman CreateObject(string line)
        {
            var splitedData = line.Split("ç");
            return new Salesman
            {
                Cpf = splitedData[1],
                Name = splitedData[2],
                Salary = Convert.ToDecimal(splitedData[3])
            };
        }

        public List<Salesman> GetListSalesman(string file)
        {
            List<Salesman> listSalesman = new();

            string[] lines = System.IO.File.ReadAllLines(file);

            foreach (var line in lines.Where(x => x.StartsWith("001")).ToArray())
            {
                listSalesman.Add(CreateObject(line));
            }

            return listSalesman;
        }
    }
}

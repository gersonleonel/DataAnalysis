#region usings
using DataAnalysis.Domain.Models;
using System.Collections.Generic;
#endregion usings

namespace DataAnalysis.Domain.Interfaces
{
    public interface ISalesmanService
    {
        Salesman CreateObject(string line);
        List<Salesman> GetListSalesman(string file);
    }
}

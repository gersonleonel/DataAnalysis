#region usings
using DataAnalysis.Domain.Models;
using System.Collections.Generic;
#endregion usings

namespace DataAnalysis.Domain.Interfaces
{
    public interface IClientService
    {
        Client CreateObject(string line);
        List<Client> GetListClient(string file);
    }
}

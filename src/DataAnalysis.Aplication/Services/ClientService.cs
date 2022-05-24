#region usings
using DataAnalysis.Domain.Interfaces;
using DataAnalysis.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion usings

namespace DataAnalysis.Aplication.Services
{
    public class ClientService : IClientService
    {

        public Client CreateObject(string line)
        {
            var splitedData = line.Split("ç");
            return new Client
            {
                Cnpj = splitedData[1],
                Name = splitedData[2],
                BusinessArea = splitedData[3],                
            };
        }

        public List<Client> GetListClient(string file)
        {
            List<Client> listClient = new();

            var lines = File.ReadAllLines(file);

            foreach (var line in lines.Where(x => x.StartsWith("002")).ToArray())
            {
                listClient.Add(CreateObject(line));
            }

            return listClient;
        }
    }
}

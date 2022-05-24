#region usings
using DataAnalysis.Domain.Interfaces;
using DataAnalysis.Domain.Models;
using System.Collections.Generic;
using System.Linq;
#endregion usings

namespace DataAnalysis.Aplication.Services
{
    public class WorkerService : IWorkerService
    {
        #region Conetructor
        private readonly IIOService _ioService;
        private readonly ISalesmanService _salesmanService;
        private readonly ISaleService _saleService;
        private readonly IClientService _clientService;
        public WorkerService(IIOService ioService, ISalesmanService salesmanService, ISaleService saleService, IClientService clientService)
        {
            _ioService = ioService;
            _salesmanService = salesmanService;
            _saleService = saleService;
            _clientService = clientService;
        }
        #endregion Constructor

        /// <summary>
        /// Processing the files
        /// </summary>
        public void ProcessFiles()
        {
            var files = _ioService.GetFiles();

            foreach (var file in files)
            {
                var listSalesman = _salesmanService.GetListSalesman(file);
                var listClient = _clientService.GetListClient(file);
                var listSale = _saleService.GetListSale(file);

                GenerateOutputData(file.Split("\\").Last(), listSalesman, listClient, listSale);
            }
        }

        /// <summary>
        /// Generate output data
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="listSalesman"></param>
        /// <param name="listClient"></param>
        /// <param name="listSales"></param>
        private void GenerateOutputData(string fileName, List<Salesman> listSalesman, List<Client> listClient, List<Sale> listSales)
        {
            /*
            O conteúdo do arquivo de saída deve resumir os seguintes dados:
            ● Quantidade de clientes no arquivo de entrada
            ● Quantidade de vendedor no arquivo de entrada
            ● ID da venda mais cara
            ● O pior vendedor
            */
            var outputData = $"{listClient.Count}ç{listSalesman.Count}ç{_saleService.GetBiggestSale(listSales)}ç{_saleService.GetWorstSeller(listSales)}";
            _ioService.CreateFile(fileName, outputData);
        }
    }
}

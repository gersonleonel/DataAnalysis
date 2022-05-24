#region usings
using System;
using System.IO;
#endregion usings

namespace DataAnalysis.Aplication.Services
{
    public class BaseService
    {
        protected readonly string HomePath; 
        protected readonly string InputPath; 
        protected readonly string OutputPath; 

        public BaseService()
        {
            HomePath = Environment.GetEnvironmentVariable("HOMEPATH");
            InputPath = Path.Combine(HomePath, "data", "in");
            OutputPath = Path.Combine(HomePath, "data", "out");
        }
    }
}

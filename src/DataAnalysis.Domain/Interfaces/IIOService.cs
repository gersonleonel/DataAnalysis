#region usings
using System.Collections.Generic;
#endregion usings

namespace DataAnalysis.Domain.Interfaces
{
    public interface IIOService
    {
        IEnumerable<string> GetFiles();
        void CreateFile(string fileName, string data);
    }
}

#region usings
using DataAnalysis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion usings

namespace DataAnalysis.Aplication.Services
{
    public class IOService : BaseService, IIOService
    {
        public IEnumerable<string> GetFiles()
        {
            var filesDone = Directory.GetFiles(OutputPath).Where(x => x.EndsWith(".dat")).ToArray();

            var files = Directory.GetFiles(InputPath).Where(x => 
                    x.EndsWith(".dat") && 
                    !filesDone.Any(f => f.Replace("\\out\\", "\\in\\").Replace(".done.dat", string.Empty) == x.Replace(".dat", string.Empty))
                ).ToArray();

            return files;
        }

        public void CreateFile(string fileName, string data)
        {
            string file = Path.Combine(OutputPath, fileName.Replace(".dat", ".done.dat"));
            Directory.CreateDirectory(OutputPath);
            
            File.Create(file).Dispose();
            File.WriteAllText(file, $"{data}{WaterMark()}");
        }

        #region WaterMark
        private string WaterMark()
        {
            return @"


                             _ _                 _    
                            (_) |               | |   
                  __ _  __ _ _| |__   __ _ _ __ | | __
                 / _` |/ _` | | '_ \ / _` | '_ \| |/ /
                | (_| | (_| | | |_) | (_| | | | |   < 
                 \__,_|\__, |_|_.__/ \__,_|_| |_|_|\_\
                        __/ |                         
                       |___/                          


            ";
        }
        #endregion WaterMark
    }
}

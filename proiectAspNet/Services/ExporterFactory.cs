using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectAspNet.Services
{
    public class ExporterFactory
    {
        public IExporter GetExport(string exporterType)
        {
            if (exporterType == null)
            {
                return null;
            }
            if (exporterType.Equals("csv"))
            {
                return new CSVexporter();

            }
            else if (exporterType.Equals("json"))
            {
                return new JSONexporter();

            }
            else if (exporterType.Equals("xml"))
            {
                return new XMLexporter();
            }
            
            return null;

        }
        

    }
}

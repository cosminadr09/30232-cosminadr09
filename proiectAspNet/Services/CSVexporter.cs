using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proiectAspNet.Models;
using System.IO;
using System.Text;
using ServiceStack.Text;

namespace proiectAspNet.Services
{
    public class CSVexporter : IExporter
    {
        public byte[] export2(List<Order> list)
        {
            var csv = CsvSerializer.SerializeToCsv(list);
            MemoryStream mem = new MemoryStream();
            TextWriter tw = new StreamWriter(mem);
           
    
            tw.Write(csv.ToString());
            tw.Flush();
            tw.Close();

            return mem.GetBuffer();
        }

        IExporter IExporter.Export(int id, string tip)
        {
            throw new NotImplementedException();
        }
    }
}

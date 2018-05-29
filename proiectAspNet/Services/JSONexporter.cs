using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiectAspNet.Models;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace proiectAspNet.Services
{
    public class JSONexporter : IExporter
    {
        public byte[] export2(List<Order> list)
        {
            // To convert JSON text contained in string json into an XML node
            string sJSONResponse = JsonConvert.SerializeObject(list);

            //XmlDocument doc = JsonConvert.DeserializeXmlNode(sJSONResponse);
            //string xmlResponse = XmlConvert.ToString(list.ToString());
            /*var branchesXml = list.Select(i => new XElement("branch",
                                                    new XAttribute("order", i)));
            var bodyXml = new XElement("list", branchesXml);
            System.Console.Write(bodyXml.Value);*/


            MemoryStream mem = new MemoryStream();
            TextWriter tw = new StreamWriter(mem);
            
            tw.Write(sJSONResponse);
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

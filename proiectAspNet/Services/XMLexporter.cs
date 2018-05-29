using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using proiectAspNet.Models;

namespace proiectAspNet.Services
{
    public class XMLexporter : IExporter
    {
        public IExporter Export(int id, string tip)
        {
            throw new NotImplementedException();
        }

        public byte[] export2(List<Order> list)
        {
            
            var branchesXml = list.Select(i => new XElement("branch",
                                                    new XAttribute("ID", i.ID), 
                                                    new XAttribute("OrderDate", i.OrderDate), 
                                                    new XAttribute("TotalPrice", i.TotalPrice)));
            var bodyXml = new XElement("list", branchesXml);
            System.Console.Write(bodyXml);

             MemoryStream mem = new MemoryStream();
            TextWriter tw = new StreamWriter(mem);

            string xml = bodyXml.ToString();
            tw.Write(xml);
            tw.Flush();
            tw.Close();

            return mem.GetBuffer();
            

           
        }
    }
}
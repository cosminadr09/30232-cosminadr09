using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proiectAspNet.Models;

namespace proiectAspNet.Services
{
    public interface IExporter
    {
        IExporter Export(int id, string tip);
        byte[] export2(List<Order> list);
    }
}

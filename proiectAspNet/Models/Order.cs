using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace proiectAspNet.Models
{
    [DataContract]
    //[XmlType(TypeName = "branch")]

    public class Order
    {
        //[XmlAttribute(AttributeName ="ID")]
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        //[XmlAttribute(AttributeName = "OrderDate")]
        [DataMember(Name ="OrderDate")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime OrderDate { get; set; }

        //[XmlAttribute(AttributeName = "TotalPrice")]
        [DataMember(Name ="TotalPrice")]
        public float TotalPrice { get; set; }

        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}
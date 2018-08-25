using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinancePyramid
{
    [XmlRoot("przelewy")]
    public class Transfers
    {
        [XmlElement("przelew")]
        public Transfer[] transactions; //list of transfers made
    }
}

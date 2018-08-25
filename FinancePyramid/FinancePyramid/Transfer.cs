using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinancePyramid
{
    public class Transfer
    {
        [XmlAttribute("od")]
        public int from;
        [XmlAttribute("kwota")]
        public int amount;
    }
}

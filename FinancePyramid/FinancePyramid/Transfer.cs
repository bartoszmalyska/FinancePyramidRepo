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


        /* Getters and Setters */

        public int From
        {
            get { return from; }
            set { from = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}

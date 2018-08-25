using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinancePyramid
{
    /* User Class */

    public class User
    {
        [XmlAttribute("id")]
        public int id; //id of an user
        private int level = 0; //level in the hierarchy
        [XmlElement("uczestnik")]
        public User[] under; //users that are below referenced user
        public User parent = null;
        private int prov = 0; //provision gained from all transactions
        private int leavesUnder = 0; //leaves that are below referenced user

        /* Getters and Setters */ 

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Prov
        {
            get { return prov; }
            set { prov = value; }
        }
        public User Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public int LeavesUnder
        {
            get { return leavesUnder; }
            set { leavesUnder = value; }
        }
        public User[] Under
        {
            get { return under; }
            set { under = value; }
        }
    }
}

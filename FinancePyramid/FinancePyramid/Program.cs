using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinancePyramid
{
    public class Program
    {
        static void Main(string[] args)
        {
            string dirPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            XmlDeserializer xmlDeserializer = new XmlDeserializer();

            Pyramid pyramid = xmlDeserializer.Deserialize<Pyramid>(dirPath + @"\pyramid.xml");
            pyramid.CreateList(pyramid.root);

            Transfers transfers = xmlDeserializer.Deserialize<Transfers>(dirPath + @"\transfers.xml");
            pyramid.ApplyTransfers(transfers);

            foreach (User u in pyramid.UserList)
            {
                Console.WriteLine(u.id + " " + u.Level + " " + u.LeavesUnder + " " + u.Prov);
            }
       
            Console.ReadKey();
        }
    }
}

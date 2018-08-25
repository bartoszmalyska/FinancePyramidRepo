using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinancePyramid
{

    /* Deserializer class */
    class XmlDeserializer
    {
        /* Generic deserialization */
        public T Deserialize<T>(string path) where T : class
        {
            T retObject = null;

            string xmlInputData = File.ReadAllText(path);
            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(xmlInputData))
            {
                retObject = (T)serializer.Deserialize(sr);
            }
            return retObject;
        }
    }
}

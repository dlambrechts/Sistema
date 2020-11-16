using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Servicios.SerializadorXML
{
    public class Serializador<T>
    {

        FileStream fStream;
        TextWriter writer;
        public object Serializar(object obj)
        {
            fStream = FileStreamManager.Instance.CreateFile("xml");
            writer = new StreamWriter(fStream);
            var ser = new XmlSerializer(typeof(T));
            ser.Serialize(writer, obj);
            writer.Close();
            fStream.Close();
            return fStream.Name;
        }
    }
}

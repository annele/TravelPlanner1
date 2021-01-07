using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelPlanner.Utils
{
    public static class XML
    {
        // XML load generic
        public static T Load<T>(string filename)
        {
            T locinfo;
            if (File.Exists(filename))
            {
                XmlSerializer reader = new XmlSerializer(typeof(T));
                StreamReader file = new StreamReader(filename);
                locinfo = (T)reader.Deserialize(file);
                file.Close();
                return locinfo;
            }
            else
            {
                return default(T);
            }
        }

        //XML save generic
        //save() 
        //saves __locationInformations to file
        public static void Save<T>(string filename, T type)
        {
            XmlSerializer writer = new XmlSerializer(typeof(T));
            FileStream file = File.Create(filename);
            writer.Serialize(file, type);
            file.Close();
        }
        
    }
}

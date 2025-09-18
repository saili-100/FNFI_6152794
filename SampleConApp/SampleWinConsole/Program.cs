using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SampleWinConsole
{
    internal class Program
    {
       
    [Serializable]
        class Data
        {
            public DateTime CurrentDate { get; set; } = DateTime.Now;
            public int Id { get; set; }
            public string Name { get; set; }
        }
       
            private static void binarySerializationDemo()
            {
                saveData();
                //loadData();
            }
            private static void saveData()
            {
                //What: object of class Data
                var data = new Data { Id = 123, CurrentDate = DateTime.Now.AddDays(-432), Name = "Apple" };
                //Where
                var location = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
                //How
                var formatter = new BinaryFormatter();
                formatter.Serialize(location, data);
                location.Close();
            }
            static void Main(string[] args)
            {
                binarySerializationDemo();
            }



        }


    }



































//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;
////BinarySerialization is a feature of allowing an object to be stored into a file or a database. Binary Serialization works only on Windows OS. 
//namespace SampleWinConsole
//{
//    [Serializable]//Anotations or additional logic that shall be added by the compiler to indicate that this class can be serialized.
//    class Data
//    {
//        public DateTime CurrentDate { get; set; } = DateTime.Now;
//        public int Id { get; set; }
//        public string Name { get; set; }
//    }
//    internal class Program
//    {
//        private static void binarySerializationDemo()
//        {
//            //saveData();
//            loadData();
//        }

//        //Deserialization is the process of reconstructing an object from a serialized format.
//        private static void loadData()
//        {
//            var formatter = new BinaryFormatter();
//            FileStream fs = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
//            object boxedData = formatter.Deserialize(fs);
//            fs.Close();
//            var unboxedData = boxedData as Data;
//            Console.WriteLine($"The Name: {unboxedData.Name}, Date: {unboxedData.CurrentDate}");
//        }

//        private static void saveData()
//        {
//            //What: object of class Data
//            var data = new Data { Id = 123, CurrentDate = DateTime.Now.AddDays(-432), Name = "Apple" };
//            //Where
//            var location = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);
//            //How
//            var formatter = new BinaryFormatter();
//            formatter.Serialize(location, data);
//            location.Close();
//        }

//        static void Main(string[] args)
//        {
//            binarySerializationDemo();
//        }
//    }
//}
///////////////////////////////////////////////////////////////////////////
//using System;
//using System.Xml.Serialization;

//Serialization is a feature of allowing an object to be stored into a file or a database. Here we store the object in a file. Not the data.
//The object typically has a class definition, metadata and other information that allows it to be reconstructed later.
//This is useful for persisting the state of an object or transferring it over a network. Mostly used for IPC.
//.NET supports serialization thru' BinaryFormatter(Binary), XmlSerializer(Xml), DataContractSerializer(WCF), and JSON serialization(JSON).
//Any Serialization has 3 steps: What to Serialize(objects of a class that has attribute called Serializable), How to Serialize(Binary, Xml, Soap, Json, WCF), and Where to Serialize(Files, Memory Streams, databases).
//For Xml Serialization, the class must have a parameterless constructor and public properties. The class must be public.
//namespace SampleConApp
//{
//    public class Data
//    {
//        public DateTime CurrentDate { get; set; } = DateTime.Now;
//        public int Id { get; set; }
//        public string Name { get; set; }
//    }

//    internal class Ex22SerializationExample
//    {
//        static void Main(string[] args)
//        {
//            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Data));
//            //var data = new Data { Id = 123, CurrentDate = DateTime.Now.AddDays(-432), Name = "Apple" };
//            //xmlSerializer.Serialize(new System.IO.StreamWriter("data.xml"), data);
//            var data = (Data)xmlSerializer.Deserialize(new System.IO.StreamReader("data.xml"));
//            Console.WriteLine($"The Name: {data.Name}, Date: {data.CurrentDate}");

//        }
//        //Give me an example on JsonSerialization in C# using System.Text.Json


//    }
//}

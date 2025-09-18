using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SampleConApp
{
    //[Serializable] // Annoations or additional logic added at run time
    public class Data
    {   
        public DateTime CurrentDate { get; set; } = DateTime.Now;
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal class SerializationExample
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Data));
            var data = new Data { Id = 100, CurrentDate = DateTime.Now.AddDays(-432), Name = "Strawberry" };
            xmlSerializer.Serialize(new System.IO.StreamWriter("data.xml"), data);
            //var data = (Data)xmlSerializer.Deserialize(new System.IO.StreamReader("data.xml"));
            //Console.WriteLine($"The Name: {data.Name}, Date: {data.CurrentDate}");


        }
    }
}


//using System;
//using System.Xml.Serialization;

//Serialization is a feature of allowing an object to be stored into a file or a database. Here we store the object in a file. Not the data.
//The object typically has a class definition, metadata and other information that allows it to be reconstructed later.
//This is useful for persisting the state of an object or transferring it over a network. Mostly used for IPC.
//.NET supports serialization thru' BinaryFormatter(Binary), XmlSerializer(Xml), DataContractSerializer(WCF), and JSON serialization(JSON).
//Any Serialization has 3 steps: What to Serialize(objects of a class that has attribute called Serializable), How to Serialize(Binary, Xml, Soap, Json, WCF), and Where to Serialize(Files, Memory Streams, databases).
//For Xml Serialization, the class must have a parameterless constructor and public properties. The class must be public.
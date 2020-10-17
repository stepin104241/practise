using System;
using System.IO;
using System.Xml.Serialization;

namespace XML
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Phone}");
        }
    }
    class SerializationXML
    {
        static void Main(string[] args)
        {
            xmlExample();
            //Console.ReadKey();
        }

        private static void xmlExample()
        {
            Console.WriteLine("What do You want to do today: Read or Write (R/W)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "r")
                deserializingXml();
            else
                serializingXml();
        }

        private static void deserializingXml()
        {
            try
            {
                XmlSerializer sl = new XmlSerializer(typeof(Student));
                FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
                Student s = (Student)sl.Deserialize(fs);
                //old style type casting(UNBOXING)
                Console.WriteLine(s);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serializingXml()
        {
            Student s = new Student();
            Console.WriteLine("Enter the name");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter the Adress");
            s.Address = Console.ReadLine();
            Console.WriteLine("Enter the Phone Number");
            s.Phone = long.Parse(Console.ReadLine());
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sl = new XmlSerializer(typeof(Student));
            sl.Serialize(fs, s);
            fs.Flush();//Clears the buffer into the destination so that no unused stream is left over before U close the Stream...
            fs.Close();
        }
    }
}
/*
Limits of serialization:
data can easily get corruptted. 
File reading and writing is not good for multi user environment. 
While writing U will not be able to read the data. 
If more users are using the program, scalability becomes a problem.
These limits are handled if U store the data in an external software called database...
*/

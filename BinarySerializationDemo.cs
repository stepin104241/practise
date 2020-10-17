using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    class Vehicle
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string ChasisNo { get; set; }
        public float Mileage { get; set; }
        public override string ToString()
        {
            return string.Format($"Model: {Model}\nBrand: {Brand}\nChasis No: {ChasisNo}\nMileage: {Mileage}");
        }
    }
    class BinarySerializationDemo
    {
        static void Main(string[] args)
        {
            BinarySerialization();
        }
        private static void BinarySerialization()
        {
            Console.Write("Serialize or Deserialize? (S/D): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "s")
                serialize();
            else
                deserialize();
        }

        private static void serialize()
        {
            Vehicle s = new Vehicle { Model = "i20", Brand = "Hyundai", ChasisNo = "HY0022002019007878", Mileage = 18.2f };
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, s);
            fs.Close();
        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Vehicle s = bf.Deserialize(fs) as Vehicle;
            Console.WriteLine(s.Model);
            Console.WriteLine(s.Brand);
            Console.WriteLine(s.ChasisNo);
            Console.WriteLine(s.Mileage);
            fs.Close();
        }
    }
}

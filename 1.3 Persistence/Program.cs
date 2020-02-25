using System;
using System.IO;

namespace _1._3_Persistence
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data(45021, "Hello Database!", DateTime.Now);

            Save(data);

            Data newData = Load();

            Print(newData);
        }


        private static void Save(Data data)
        {
            using (FileStream fileStream = new FileStream("database.txt", FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(data.someInteger);
                    writer.Write(',');
                    writer.Write(data.someString);
                    writer.Write(',');
                    writer.WriteLine(data.someDateTime.Ticks);
                    writer.Close();
                }
            }
        }

        private static Data Load()
        {
            using (FileStream fileStream = new FileStream("database.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string dataEntry = reader.ReadLine();


                    string[] dataComponents = dataEntry.Split(',');

                    return new Data(){
                        someInteger = int.Parse(dataComponents[0]),
                        someString = dataComponents[1],
                        someDateTime = new DateTime(long.Parse(dataComponents[2])) 
                    };
                }
            }
        }

        private static void Print(Data data)
        {
            Console.WriteLine($"Integer: {data.someInteger}");
            Console.WriteLine($"String: {data.someString}");
            Console.WriteLine($"Date-time {data.someDateTime.ToString()}");
        }
    }
}

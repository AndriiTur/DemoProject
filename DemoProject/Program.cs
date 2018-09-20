using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
    //3) Утворити List фруктів і додати до нього 5 різних фруктів і цитрусів.
    //Видрукувати дані про ті фрукти, колір яких є 'жовтий'.
    //Посортувати список фруктів за назвою і результат вивести у файл
    //Передбачити перехоплення виняткових ситуацій
    //Сериалізувати-десериалізувати список у Xml форматі
    //Написати юніт-тести на методи класів

    class Program
    {
        public const string FreshFruitData = @"\FruitsBasketData.txt";
        public const string SortedFruits = @"\sortedFruits.txt";
        public const string FreshFruitXML = @"\FruitsBasket.xml";

        static void Main(string[] args)
        {
            FruitsBasket fruitsBasket = new FruitsBasket();
            var currentDir = Directory.GetCurrentDirectory();

            if (FileHelper.CheckFile(currentDir + FreshFruitData))
            {
                //Load Fruits from File
                Console.WriteLine("Load Fruits in Basket from File");
                fruitsBasket = FileHelper.LoadFromFile(currentDir + FreshFruitData);
            }
            else
            {
                //Load Fruits from Console
                Console.WriteLine("Load Fruits in Basket from console");
                for (int i = 0; i < 4; i++)
                {
                    if (i < 2)
                    {
                        fruitsBasket.Add(new Fruit());
                        fruitsBasket.FruitsColection[i].Input();
                    }
                    else
                    {
                        fruitsBasket.Add(new Citrus());
                        fruitsBasket.FruitsColection[i].Input();
                    }
                }
            }
            //FileHelper.SaveToFile(currentDir + FreshFruitData, fruitsBasket.FruitsColection);
            Console.WriteLine("\nPrint All Fruits\n");
            foreach (var fruit in fruitsBasket.FruitsColection)
            {
                fruit.Print();
            }

            //Print list fruit with color
            Console.Write("\nEnter Fruits color: ");
            string color = Console.ReadLine();
            IEnumerable<Fruit> fruitsChoosenColor = fruitsBasket.ShowFruitWithColor(fruitsBasket.FruitsColection, color);

            if (fruitsChoosenColor.Count() > 0)
            {
                Console.Write($"\nAll Fruits with color {color}\n");
                foreach (var fruit in fruitsChoosenColor)
                {
                    fruit.Print();
                }
            }
            else
            {
                Console.Write($"\nCan't find fruits with color{color}\n");
            }

            //Sort Fruits by parameter
            Console.Write("\nSort Fruits by name\n");
            IEnumerable<Fruit> sortedFruits = fruitsBasket.Sort("");
            //fruitsBasket.Sort();

            //Print Sorted Fruits in File
            Console.Write("\nSave To file sorted Fruits\n");
            FileHelper.SaveToFile(currentDir + SortedFruits, sortedFruits);
            //FileHelper.SaveToFile(SortedFruits, fruitsBasket.FFruits);

            Console.WriteLine("");

            //Print Sorted Fruits in console
            Console.Write("\nShow sorted Fruits\n");
            foreach (var fruit in sortedFruits)
            {
                fruit.Print();
            }

            Console.Write("\nSerialize Fruits\n");
            SerializerHelper.SerializeXml(fruitsBasket, currentDir + FreshFruitXML);

            Console.Write("\nDeserialize Fruits\n");

            if (!FileHelper.CheckFile(currentDir + FreshFruitXML))
                throw new Exception("File not Found");

            FruitsBasket deserializeFruits = (FruitsBasket)SerializerHelper.XmlToObject<FruitsBasket>(
                FileHelper.FileToString(currentDir + FreshFruitXML));
            if (deserializeFruits == null)
                throw new Exception("XML Parsing Error");

            Console.Write("\nShow deserialize Fruits\n");
            foreach (var fruit in sortedFruits)
            {
                fruit.Print();
            }

            Console.Write("\nPress any key....");
            Console.ReadKey();
        }
    }
}

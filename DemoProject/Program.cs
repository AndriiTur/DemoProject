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
        public const string FreshFruitData = @"\FruitsBasket.txt";
        public const string SortedFruits = @"\sortedFruits.txt";
        public const string FreshFruitXML = @"\FruitsBasket.xml";

        static void Main(string[] args)
        {
            FruitsBasket fruitsBasket = new FruitsBasket();
            var currentDir = Directory.GetCurrentDirectory();

            if (FileHelper.CheckFile(currentDir + FreshFruitData))
            {
                //Load Fruits from File
                fruitsBasket = FileHelper.LoadFromFile(currentDir + FreshFruitData);
            }
            else
            {
                //Load Fruits from Console
                for (int i = 0; i < 5; i++)
                {
                    if (i < 3)
                    {
                        fruitsBasket.Add(new Fruit());
                        fruitsBasket.FFruits[i].Input();
                    }
                    else
                    {
                        fruitsBasket.Add(new Citrus());
                        fruitsBasket.FFruits[i].Input();
                    }
                }
            }

            //Print list fruit with color
            IEnumerable<Fruit> yellowFruits = fruitsBasket.ShowFruitWithColor(fruitsBasket.FFruits, "yellow");

            Console.WriteLine("");

            foreach (var fruit in yellowFruits)
            {
                fruit.Print();
            }

            //Sort Fruits by parameter
            IEnumerable<Fruit> sortedFruits = fruitsBasket.Sort("");
            //fruitsBasket.Sort();

            //Print Sorted Fruits in File
            FileHelper.SaveToFile(currentDir + SortedFruits, sortedFruits);
            //FileHelper.SaveToFile(SortedFruits, fruitsBasket.FFruits);

            Console.WriteLine("");

            //Print Sorted Fruits in console
            foreach (var fruit in sortedFruits)
            {
                fruit.Print();
            }

            string fruitsBasketXML = "";
            foreach (var fr in fruitsBasket.FFruits)
            {
                fruitsBasketXML = SerializerHelper.ObjectToXml<Fruit>(fr);
                Console.WriteLine(fruitsBasketXML);
            }
            //string fruitsBasketXML = SerializerHelper.ObjectToXml<List<Fruit>>(fruitsBasket.FFruits);

            //FileHelper.SaveXMLToFile(currentDir + FreshFruitXML, fruitsBasketXML);

            //Console.WriteLine(fruitsBasketXML);
            Console.ReadKey();
        }
    }
}

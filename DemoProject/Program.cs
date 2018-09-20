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
        public const string FreshFruitData = @"\freshFruits.txt";
        public const string SortedFruits = @"\sortedFruits.txt";
        public const string FreshFruitXML = @"\freshFruits.xml";

        static void Main(string[] args)
        {
            FruitBasket freshFruits = new FruitBasket();
            var currentDir = Directory.GetCurrentDirectory();

            freshFruits.Add(new Fruit("banana", "yellow"));

            freshFruits.ShowFruitWithColor(freshFruits, "yellow");

            freshFruits.Sort();

            FileHelper.StringToFile(currentDir + SortedFruits, ListToString(sortedfruits));

            foreach (var fFruit in freshFruits)
            {
                SerializerHelper.ObjectToXml<Fruit>(fFruit);
            }
        }

        private static void ShowFruitWithColor(FruitBasket freshFruits, string color)
        {
            foreach (Fruit fFruit in freshFruits)
            {
                if (fFruit.Color == color.ToLower())
                {
                    Console.WriteLine(fFruit);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
    class Program
    {
        public const string FreshFruitData = @"\freshFruits.txt";
        public const string SortedFruits = @"\sortedFruits.txt";
        public const string FreshFruitXML = @"\freshFruits.xml";

        static void Main(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();
            List<Fruit> freshFruits = new List<Fruit>();

            ShowFruitWithColor(freshFruits, "");

            freshFruits.Sort();

            FileHelper.StringToFile(currentDir + SortedFruits, ListToString(sortedfruits));

            foreach (var fFruit in freshFruits)
            {
                SerializerHelper.ObjectToXml<Fruit>(fFruit);
            }
        }

        private static string ListToString(IEnumerable<Fruit> sortedfruits)
        {
            string stringFruits = "";
            foreach (var fruit in sortedfruits)
            {
                stringFruits += $"{fruit}\n";
            }
            return stringFruits;
        }

        private static void ShowFruitWithColor(List<Fruit> freshFruits, string color)
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

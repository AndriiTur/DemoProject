using System;
using System.Collections.Generic;
using System.IO;

namespace DemoProject
{
    public class FileHelper
    {
        public static string FileToString(string path)
        {
            if (File.Exists(path))
                return File.ReadAllText(path);
            else
                return "";
        }

        public static void SaveToFile(string path, string str)
        {
            File.AppendAllText(path, str);
        }

        public static void SaveToFile(string path, List<Fruit> Fruits)
        {
            foreach (Fruit fruit in Fruits)
            {
                fruit.Print(path);
            }
        }

        
        public static void SaveToFile(string path, IEnumerable<Fruit> Fruits)
        {
            foreach (Fruit fruit in Fruits)
            {
                fruit.Print(path);
            }
        }

        /// <summary>
        /// Load Fruits from File
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>FruitsBasket(colletion)</returns>
        public static FruitsBasket LoadFromFile(string path)
        {
            FruitsBasket freshFruits = new FruitsBasket();
            string[] fruits = FileHelper.FileToString(path).Split(new char[] { '\n' });

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fruit = sr.ReadLine().Split(new char[] { '-', '/' });
                    if (fruit.Length == 2)
                    {
                        Fruit newFruit = new Fruit();
                        newFruit.Input(fruit);
                        freshFruits.Add(newFruit);
                    }
                    else if (fruit.Length == 3)
                    {
                        Fruit newFruit = new Citrus();
                        newFruit.Input(fruit);
                        freshFruits.Add(newFruit);
                    }
                }
            }

            return freshFruits;
        }

        /// <summary>
        /// Check File Exists
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>bool (true/false)</returns>
        internal static bool CheckFile(string path)
        {
            return File.Exists(path) && new FileInfo(path).Length > 0;
        }
    }
}

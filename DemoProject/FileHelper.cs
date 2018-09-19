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

        public static void StringToFile(string path, string str)
        {
            File.AppendAllText(path, str);
        }

        public static void ListToFile(string path, FruitsBasket freshFruits)///!!!!!!!!!!!!!!
        {
            FileHelper.StringToFile(path, freshFruits.ListToString((IEnumerable<Fruit>)freshFruits));
        }

        public static FruitsBasket FileToList(string path)
        {
            FruitsBasket freshFruits = new FruitsBasket();
            string[] fruits = FileHelper.FileToString(path).Split(new char[] { '\n' });

            for (int i = 0; i < fruits.Length; i++)
            {
                string[] fruit = fruits[i].Split(new char[] { '-',':' });
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
            return freshFruits;
        }

        internal static bool CheckFile(string path)
        {
            return File.Exists(path) && File.ReadAllText(path).Length != 0;
        }
    }
}

using System;
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

        public void ListToFile(string path, FreshFruits freshFruits)
        {
            FileHelper.StringToFile(path, freshFruits.ListToString());
        }

        public FreshFruits FileToList(string path)
        {
            FreshFruits freshFruits = new FreshFruits();
            string[] fruits = FileHelper.FileToString(path).Split(new char[] { '\n' });

            for (int i = 0; i < fruits.Length; i++)
            {
                string[] fruit = fruits[i].Split(new char[] { '-' });
                if (fruit.Length == 2)
                {
                    freshFruits.Add(new Fruit(fruit[0], fruit[1]));
                }
                else if (fruit.Length == 3)
                {
                    freshFruits.Add(new Citrus(fruit[0], fruit[1], ToDouble(fruit[2])));
                }
            }
            return freshFruits;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoProject
{
    class FreshFruits
    {
        private List<Fruit> fFruits;

        [XmlArray("FreshFruits"), XmlArrayItem(typeof(Fruit), ElementName = "")]
        public List<Fruit> FFruits { get => fFruits; set => fFruits = value; }

        public FreshFruits()
        {
            fFruits = new List<Fruit>();
        }

        public void Add(Fruit fruit)
        {
            this.FFruits.Add(fruit);
        }

        public void Remove(Fruit fruit)
        {
            this.FFruits.Remove(fruit);
        }

        public void AddRank(List<Fruit> fFruits)
        {
            this.fFruits.AddRange(fFruits);
        }

        public void Sort(string sortedValue = "")
        {
            if (sortedValue.ToLower() == "name")
            {
                this.FFruits.OrderBy(f => f.Name);
            }
            else if (sortedValue.ToLower() == "color")
            {
                this.FFruits.OrderBy(f => f.Color);
            }
            else
            {
                this.FFruits.OrderBy(f => f.Name);
            }
        }

        private string ListToString()
        {
            string stringFruits = "";
            foreach (var fruit in this.fFruits)
            {
                stringFruits += $"{fruit.Name}-{fruit.Name}\n";
            }
            return stringFruits;
        }

        public void ListToFile(string path, )
        {
            FileHelper.StringToFile(path, ListToString());
        }

        public void FileToList(string path)
        {
            string[] fruits =  FileHelper.FileToString(path).Split(new char[] {'\n'});

            for (int i =0; i < fruits.Length; i++)
            {
                string[] fruit = fruits[i].Split(new char[] { '-' });
                if (fruit.Length == 2)
                {
                    this.Add(new Fruit(fruit[0], fruit[1]));
                }
                else if (fruit.Length == 3)
                {
                    this.Add(new Citrus(fruit[0], fruit[1], ToDouble(fruit[2])));
                }
            }
        }

        private double ToDouble(string value)///Dopusatu!!!!!!!!!!!!!!!!!!!!
        {
            return double.Parse(value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoProject
{
    public class FruitBasket
    {
        private List<Fruit> fFruits;

        [XmlArray("FreshFruits"), XmlArrayItem(typeof(Fruit), ElementName = "")]
        public List<Fruit> FFruits { get => fFruits; set => fFruits = value; }

        public FruitBasket()
        {
            fFruits = new List<Fruit>();
        }

        public void Add(Fruit fruit)
        {
            FFruits.Add(fruit);
        }

        public void Remove(Fruit fruit)
        {
            FFruits.Remove(fruit);
        }

        public void AddRank(List<Fruit> fFruits)
        {
            FFruits.AddRange(fFruits);
        }

        public void Sort(string sortedValue = "")
        {
            if (sortedValue.ToLower() == "name")
            {
                FFruits.OrderBy(f => f.Name);
            }
            else if (sortedValue.ToLower() == "color")
            {
                FFruits.OrderBy(f => f.Color);
            }
            else
            {
                FFruits.OrderBy(f => f.Name);
            }
        }

        internal void ShowFruitWithColor(string color)
        {
            foreach (Fruit fruit in FFruits)
            {
                if (fruit.Color == color)
                {
                    Console.WriteLine(fruit);
                }
            }
        }

        public void PrintToFile(string path)
        {
            foreach (var fruit in this.fFruits)
            {
                fruit.Print(path);
            }
        }

        private double ToDouble(string value)///Dopusatu!!!!!!!!!!!!!!!!!!!!
        {
            return double.Parse(value);
        }
    }
}

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

        public string ListToString()
        {
            string stringFruits = "";
            foreach (var fruit in this.fFruits)
            {
                stringFruits += $"{fruit.Name}-{fruit.Name}\n";
            }
            return stringFruits;
        }

        private double ToDouble(string value)///Dopusatu!!!!!!!!!!!!!!!!!!!!
        {
            return double.Parse(value);
        }
    }
}

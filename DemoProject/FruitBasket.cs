using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoProject
{
    public class FruitsBasket
    {
        private List<Fruit> fFruits;

        [XmlArray("FreshFruits"), XmlArrayItem(typeof(Fruit), ElementName = "FF")]
        public List<Fruit> FFruits { get => fFruits; set => fFruits = value; }

        public FruitsBasket()
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

        public IEnumerable<Fruit> Sort(string sortedValue = "")
        {
            if (sortedValue.ToLower() == "name")
            {
                return FFruits.OrderBy(f => f.Name);
            }
            else if (sortedValue.ToLower() == "color")
            {
                return FFruits.OrderBy(f => f.Color).ThenBy(f => f.Name);
            }
            else
            {
                return FFruits.OrderBy(f => f.Name);
            }
        }

        public static string ListToString(IEnumerable<Fruit> fFruits)
        {
            string stringFruits = "";
            foreach (var fruit in fFruits)
            {
                stringFruits += $"{fruit.Name}-{fruit.Name}\n";
            }
            return stringFruits;
        }

        private double ToDouble(string value)///Dopusatu!!!!!!!!!!!!!!!!!!!!
        {
            return double.Parse(value);
        }

        internal IEnumerable<Fruit> ShowFruitWithColor(List<Fruit> fFruits, string color)
        {
            return this.FFruits.Where(f => f.Color == color.ToLower());
        }
    }
}

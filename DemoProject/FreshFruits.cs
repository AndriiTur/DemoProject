using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoProject
{
    public class FreshFruits
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

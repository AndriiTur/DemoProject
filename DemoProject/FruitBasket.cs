using System.Collections.Generic;
using System.Linq;

namespace DemoProject
{
    [Serializable]
    public class FruitsBasket
    {
        private List<Fruit> fruitsColection;

        public List<Fruit> FruitsColection { get => fruitsColection; set => fruitsColection = value; }

        public FruitsBasket()
        {
            fruitsColection = new List<Fruit>();
        }

        public void Add(Fruit fruit)
        {
            this.FruitsColection.Add(fruit);
        }

        public void Remove(Fruit fruit)
        {
            this.FruitsColection.Remove(fruit);
        }

        public void AddRank(List<Fruit> fFruits)
        {
            this.fruitsColection.AddRange(fFruits);
        }

        public void Sort()
        {
            this.fruitsColection.Sort();
        }

        public IEnumerable<Fruit> Sort(string sortedValue = "")
        {
            if (sortedValue.ToLower() == "name")
            {
                return FruitsColection.OrderBy(f => f.Name);
            }
            else if (sortedValue.ToLower() == "color")
            {
                return FruitsColection.OrderBy(f => f.Color).ThenBy(f => f.Name);
            }
            else
            {
                return FruitsColection.OrderBy(f => f.Name);
            }
        }

        internal IEnumerable<Fruit> ShowFruitWithColor(List<Fruit> fFruits, string color)
        {
            return this.FruitsColection.Where(f => f.Color == color.ToLower());
        }
    }
}

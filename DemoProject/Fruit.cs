using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoProject
{
    [XmlRoot("FreshFruits")]
    public class Fruit: IComparable<Fruit>
    {
        private string name;
        private string color;

        [XmlAnyAttribute]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [XmlAnyAttribute]
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value.ToLower();

            }
        }

        public Fruit()
        {
        }

        public Fruit(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public virtual void Input(string path)
        {
            FileHelper.StringToFile(path, this.ToString());
        }

        public virtual void Output()
        {
            //write to console-file
        }

        public override string ToString()
        {
            return $"Fruit name:{this.name} fruit color: {this.color}";
        }

        public int CompareTo(Fruit other)
        {
            return this.name.CompareTo(other.name);
        }
    }
}

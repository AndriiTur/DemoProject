using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoProject
{
    [XmlRoot("FreshFruits")]
    public class Citrus : Fruit
    {
        double concentrationVitaminC;

        [XmlAnyAttribute]
        public double ConcentrationVitaminC
        {
            get
            {
                return concentrationVitaminC;
            }
            set
            {
                concentrationVitaminC = value;
            }
        }

        public Citrus()
        {
        }

        public Citrus(string name, string color, double concentrationVitaminC) : base(name, color)
        {
            this.concentrationVitaminC = concentrationVitaminC;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Input()
        {
            SerializerHelper.ObjectToXml<Citrus>(this);
            //read from console-file
        }

        public override void Output()
        {
            //write to console-file
        }

        public override string ToString()
        {
            return $"Fruit name:{this.Name} fruit color: {this.Color} concentration Vitamin C: {this.ConcentrationVitaminC}";
        }
    }
}

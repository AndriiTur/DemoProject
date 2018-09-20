using System;
using System.Xml.Serialization;

namespace DemoProject
{
    //2) Утворити похідний від нього клас Цитрус, який має:
    //поле - вміст вітаміну С в грамах, 
    //конструктор з параметрами, 
    //властивість, 
    //перевизначені методи Input() та Print().

    [XmlRoot("FreshFruits")]
    public class Citrus : Fruit
    {
        //Fields
        private double vitaminC;

        //Properties
        [XmlAnyAttribute]
        public double VitaminC
        {
            get
            {
                return vitaminC;
            }
        }

        //Constructors
        public Citrus()
        {
        }

        public Citrus(string name, string color, double vitaminC) : base(name, color)
        {
            this.vitaminC = vitaminC;
        }

        //Methods
        private bool SetVitaminC(string value)
        {
            value.Replace(',', '.');
            value.Replace('/', '.');
            value.Replace(':', '.');
            value.Replace('-', '.');
            value.Replace(' ', '.');
            try
            {
                vitaminC = double.Parse(value);
            }
            catch (FormatException e)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.Error.WriteLine(e.Message);
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.Error.WriteLine(e.Message);
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.Error.WriteLine(e.Message);
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            return true;
        }

        //Methods Inputs
        public override void Input()
        {
            bool isSetted = false;
            Console.Write("Citrus Name: ");
            Name = Console.ReadLine();
            Console.Write($"\"{Name}\" Color : ");
            Color = Console.ReadLine();
            Console.Write($"\"{Name}\" VitaminC(double): ");
            isSetted = SetVitaminC(Console.ReadLine());

            while (!isSetted)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: \"You enter wrong value, enter again\"");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.Write("Citrus VitaminC(double): ");
                isSetted = SetVitaminC(Console.ReadLine());
            }
        }

        public override void Input(string[] fruit)
        {
            Name = fruit[0];
            Color = fruit[1];
            SetVitaminC(fruit[2]);
        }

        //Methods Print
        public override void Print()
        {
            Console.WriteLine($"{this}");
        }

        public override void Print(string pathToFile)
        {
            FileHelper.SaveToFile(pathToFile, $"{Name}/{Color}/{VitaminC}");
        }

        //Overrides Method ToString
        public override string ToString()
        {
            return $"Name:{this.Name} Color: {this.Color} Concentration Vitamin C: {this.vitaminC}";
        }
    }
}

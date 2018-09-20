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
        double vitaminC;

        [XmlAnyAttribute]
        public double VitaminC
        {
            get
            {
                return vitaminC;
            }
            private set {}
        }

        public Citrus()
        {
        }

        public Citrus(string name, string color, double vitaminC) : base(name, color)
        {
            VitaminC = vitaminC;
        }

        private bool SetVitaminC(string value)
        {
            value.Replace(',', '.');
            value.Replace('/', '.');
            value.Replace(':', '.');
            value.Replace('-', '.');
            value.Replace(' ', '.');
            double resultValue = 0.0;

            try
            {
                resultValue = double.Parse(value);
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
            VitaminC = resultValue;
            return true;
        }

        public override void Input()
        {
            bool isSetted = false;
            Console.Write("Citrus Name: ");
            Name = Console.ReadLine();
            Console.Write($"Citrus Color {Name}: ");
            Color = Console.ReadLine();
            Console.Write("Citrus VitaminC(double): ");
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

        public override void Print()
        {
            Console.WriteLine($"{this}");
        }

        public override void Print(string pathToFile)
        {
            FileHelper.StringToFile(pathToFile, $"{Name}:{Color}-{VitaminC}");
            FileHelper.SaveToFile(pathToFile, $"{Name}/{Color}/{VitaminC}");
        }

        public override string ToString()
        {
            return $"Fruit name:{this.Name} fruit color: {this.Color} concentration Vitamin C: {this.vitaminC}";
        }
    }
}

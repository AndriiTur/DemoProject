using System;
using System.Xml.Serialization;

namespace DemoProject
{
    //1) Утворити клас Фрукт, який містить:
    //поля назва та колір,
    //визначити конструктор з параметрами,
    //віртуальні методи Input() та Print(), для зчитування даних з консолі та виведення даних на консоль, а також перевантажити варіанти введення-виведення з файлу.
    //властивості для полів, 
    //перевизначити метод ToString(). 

    [XmlRoot("FreshFruits")]
    public class Fruit
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

        public virtual void Input()
        {
            Console.Write("Fruit Name: ");
            Name = Console.ReadLine();
            Console.Write("Fruit Color: ");
            Color = Console.ReadLine();
        }

        public virtual void Input(string[] fruit)
        {
            Name = fruit[0];
            Color = fruit[1];
        }

        public virtual void Print()
        {
            Console.WriteLine($"{this}");
        }

        public virtual void Print(string pathToFile)
        {
            FileHelper.StringToFile(pathToFile, $"{Name}/{Color}");
        }

        public override string ToString()
        {
            return $"Fruit name:{this.name} fruit color: {this.color}";
        }
    }
}

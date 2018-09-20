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

    [Serializable]
    [XmlInclude(typeof(Citrus))]
    public class Fruit: IComparable<Fruit>
    {
        //Fields
        private string name;
        private string color;

        //Properties
        [XmlAttribute]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.ToLower();
            }
        }

        [XmlAttribute]
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

        //Constructors
        public Fruit()
        {
        }

        public Fruit(string name, string color)
        {
            Name = name;
            Color = color;
        }

        //Methods Inputs
        public virtual void Input()
        {
            Console.Write("Fruit Name: ");
            Name = Console.ReadLine();
            Console.Write($"Enter \"{Name}\" Color: ");
            Color = Console.ReadLine();
        }

        public virtual void Input(string[] fruit)
        {
            Name = fruit[0];
            Color = fruit[1];
        }

        //Methods Prints
        public virtual void Print()
        {
            Console.WriteLine($"{this}");
        }

        public virtual void Print(string pathToFile)
        {
            FileHelper.SaveToFile(pathToFile, $"{Name}/{Color}\n");
        }

        public override string ToString()
        {
            return $"Name: {Name} Color: {Color}";
        }

        public int CompareTo(Fruit other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}

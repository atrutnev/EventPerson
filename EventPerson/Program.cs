using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPerson
{
    class Program
    {
        static void Main(string[] args)
        {

            Person dude = new Person("Jack", 37);
            dude.NameChanged += OnNameChanged;
            dude.NameChanging += OnNameChanging;
            dude.AgeChanged += OnAgeChanged;
            dude.AgeChanging += OnAgeChanging;
            dude.OnAgeError += OnAgeError;
            dude.OnNameError += OnNameError;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Person - имя: {0}, возраст: {1}", dude.Name, dude.Age);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите новое имя: ");
                Console.ForegroundColor = ConsoleColor.White;
                dude.Name = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите новый возраст: ");
                Console.ForegroundColor = ConsoleColor.White;
                dude.Age = (int.Parse(Console.ReadLine()));

                Console.ReadKey();
            }

        }

        static void OnNameChanged(object sender, NameChanged e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Имя изменено на {0}", e.NewName);
            Console.WriteLine(new string('=', 79));
        }

        static void OnNameChanging(object sender, NameChanging e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', 79));
            Console.WriteLine("Параметр \"имя\" изменяется с {0} на {1}", e.OldName, e.NewName);
        }

        static void OnAgeChanged(object sender, AgeChanged e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Возраст изменен на {0}", e.newAge);
            Console.WriteLine(new string('=', 79));
        }

        static void OnAgeChanging(object sender, AgeChanging e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Параметр \"возраст\" изменяется с {0} на {1}", e.OldAge, e.NewAge);
            Console.WriteLine(new string('=', 79));
        }

        static void OnAgeError(object sender, AgeChanged e)
        {
            Console.WriteLine("Некорректное значение возраста! - {0}", e.newAge);
            Console.WriteLine(new string('=', 79));
        }

        static void OnNameError(object sender, NameChanged e)
        {
            Console.WriteLine("Некорректное значение имени! - {0}", e.NewName);
            Console.WriteLine(new string('=', 79));
        }
    }
}

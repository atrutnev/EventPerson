using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPerson
{
    class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }



        public event EventHandler<NameChanging> NameChanging;
        public event EventHandler<NameChanged> NameChanged;
        public event EventHandler<NameChanged> OnNameError;
        public event EventHandler<AgeChanging> AgeChanging;
        public event EventHandler<AgeChanged> AgeChanged;
        public event EventHandler<AgeChanged> OnAgeError;


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.NameChanging != null)
                {
                    int index = 0;
                    foreach (var c in value.Substring(index))
                    {
                        if (!char.IsLetter(c))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            this.OnNameError(this, new NameChanged(value));
                            throw new Exception(string.Format("Имя должно содержать только буквы!\n", value));
                        }
                        index++;
                    }
                    this.NameChanging(this, new NameChanging(value, this.name));
                }

                this.name = value;

                if (this.NameChanged != null)
                {
                    this.NameChanged(this, new NameChanged(value));
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    this.OnAgeError(this, new AgeChanged(value));
                    throw new Exception(string.Format("Новорожденные и ещё нерождённые не учитываются! Возраст должен быть больше нуля!\n", value));
                }

                if (value > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    this.OnAgeError(this, new AgeChanged(value));
                    throw new Exception(string.Format("К сожалению, столько не живут. Возраст не должен превышать значение 100!\n", value));
                }

                if (this.AgeChanging != null)
                {
                    this.AgeChanging(this, new AgeChanging(value, this.age));
                }

                this.age = value;

                if (this.AgeChanged != null)
                {
                    this.AgeChanged(this, new AgeChanged(value));
                }
            }
        }
    }
}

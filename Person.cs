using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLooneyToons
{
    internal abstract class Person
    {
        internal string Type { get; set; }  //Тип персонажа
        internal string Name { get; set; }  //Имя персонажа
        internal double Attack { get; set; } //Сила атаки персонажа
        internal double Speed { get; set; }  //Скорость хода персонажа
        internal double Health { get; set; } //Здоровье персонажа
        internal double Protection { get; set; } //Защита персонажа

        public Person(string type, string name, double attack, double speed, double health, double protection)
        {
            Type = type;
            Name = name;
            Attack = attack;
            Speed = speed;
            Health = health;
            Protection = protection;
        }
        internal int udar = 1;
        protected string tipUdara = "";
        internal abstract double Attack1(Person p, Person t);
        internal abstract double Attack2(Person p, Person t);
        internal abstract void ResultCheckHealth(Person p);
        internal abstract void NewStep(Person p, Person t);


        internal bool HealthCheck(Person p)
        {
            if (p.Health > 0)
                 return true;
            else return false;
        }

        internal void ShowHealth(Person p)
        {
            if (p.Health <= 100 && p.Health >= 81)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("|==========|");
            }
            else if (p.Health <= 80 && p.Health >= 61)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("|=======___|");
            }
            else if (p.Health <= 60 && p.Health >= 30)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("|====______|");
            }
            else if (p.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|__________|");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|==________|");
            }
        }
    }
}

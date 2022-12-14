using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLooneyToons
{
    internal class Enemy : Person
    {
        public Enemy(string name, double attack, double speed, double health, double protection, string type = "Человек")
              : base(type, name, attack, speed, health, protection)
        {
            Name = "Охотник";  //Имя персонажа
            Attack = 25;       //Сила атаки персонажа
            Speed = 20;        //Скорость хода персонажа
            Health = 100;      //Здоровье персонажа
            Protection = 10;   //Защита персонажа
        }

        internal override double Attack1(Person p, Person t)   //реализация кнопки атаки #1
        {
            if (t.udar == 1)
            {
                p.Health -= t.Attack - t.Attack / 100 * p.Protection;
                tipUdara = "стреляет из лука";
            }
            else if (t.udar == 2)
            {
                t.Attack2(p, t);
                tipUdara = "стреляет дробью";
            }
            return p.Health;
        }

        internal override double Attack2(Person p, Person t)   //реализация кнопки атаки #2
        {
            p.Health -= t.Attack + 5 - (t.Attack + 5) / 100 * p.Protection;
            return p.Health;
        }

        internal override void NewStep(Person p, Person t)  //новый ход персонажа
        {
            if (p.HealthCheck(p) && t.HealthCheck(t))
            {
                Thread.Sleep(1700);
              
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\nТеперь ходит {t.Name}({t.Health})!");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============================");
                t.Attack1(p, t);
                Thread.Sleep(1100);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{t.Name} {tipUdara}!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Ваше здоровье: {p.Health}");
                t.ShowHealth(p);  
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n============================");
                
                t.ResultCheckHealth(p);
            }
        }

        internal override void ResultCheckHealth(Person p)  //итог боя(проигрыш)
        {
            if (p.Health < 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Игра окончена, вы проиграли!");
            }
        }
    }
}

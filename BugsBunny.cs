using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLooneyToons
{
    internal class BugsBunny: Person
    {
        public BugsBunny(string name, double attack, double speed, double health, double protection, string type = "Кролик")
                  : base(type, name, attack, speed, health, protection)
        {
            Name = "Bugs Bunny";  //Имя персонажа
            Attack = 20;          //Сила атаки персонажа
            Speed = 20;           //Скорость хода персонажа
            Health = 100;         //Здоровье персонажа
            Protection = 10;      //Защита персонажа
        }

        internal override double Attack1(Person p, Person t)  //реализация кнопки атаки #1
        {
            if (p.udar == 1)
            {
                t.Health -= p.Attack - p.Attack / 100 * t.Protection;
                tipUdara = "бьет дубиной";
            }
            else if (p.udar == 2)
            {
                p.Attack2(p, t);
                tipUdara = "кидает динамит";
            }
            return t.Health;
        }

        internal override double Attack2(Person p, Person t)   //реализация кнопки атаки #2
        {
            t.Health -= p.Attack + 5 - (p.Attack + 5) / 100 * t.Protection;
            return t.Health;
        }

        internal override void NewStep(Person p, Person t)  //новый ход персонажа
        {
           if (p.HealthCheck(p) && t.HealthCheck(t))
           { 
              Thread.Sleep(1100);
              Console.ForegroundColor = ConsoleColor.Green;
              Console.WriteLine("\n\n\nВаш ход!");
              
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine("============================");
              Console.Write("Выберите тип удара: <Ударить дубиной> или <Кинуть динамит>?\nДля этого введите 1 или 2: \n");
              p.udar = Convert.ToInt32(Console.ReadLine());
              Thread.Sleep(800);
              Console.WriteLine($"\n____________________________");
              Console.ForegroundColor = ConsoleColor.Green;
              p.Attack1(p, t);
              Console.WriteLine($"{p.Name}({p.Health}) {tipUdara}!");

              Console.ForegroundColor = ConsoleColor.DarkYellow;
              Console.Write($"Здоровье {t.Name}: {t.Health}");
              p.ShowHealth(t); 
              
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine("\n____________________________");
              
              p.ResultCheckHealth(t);
           }
        }

        internal override void ResultCheckHealth(Person t)  //итог боя(победа)
        {
            if (t.Health < 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Вы выйграли! {t.Name} побежден!");
            }
        }
    }
}

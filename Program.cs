using  GameLooneyToons;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Добро пожаловать в консольную игру Looney Toones!\n");
Thread.Sleep(1000);
Console.WriteLine("Начнем бой!");

Person bugs_bunny = new BugsBunny("Bugs Bunny", 10, 20, 100, 20);
Person enemy = new Enemy("Противник", 10, 20, 100, 20);

Thread.Sleep(1000);
Console.WriteLine($"Ваш персонаж: {bugs_bunny.Type} - {bugs_bunny.Name}. Ваш противник: {enemy.Type} - {enemy.Name}.");

for (int i = 0; bugs_bunny.Health > 0 && enemy.Health > 0; i++)
{
    if (enemy.Health > 0)
    {
        bugs_bunny.NewStep(bugs_bunny, enemy);
    }
    else return;

    if (bugs_bunny.Health > 0)
    {
        enemy.NewStep(bugs_bunny, enemy);
    }
    else return;
}
Console.ResetColor();


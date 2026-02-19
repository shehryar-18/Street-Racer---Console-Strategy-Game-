using System;

class Racer
{
    public string Name;
    public int Speed;
    public int Stamina;
    public int DistanceCovered;

    public Racer(string name)
    {
        Name = name;
        Speed = 0;
        Stamina = 100;
        DistanceCovered = 0;
    }

    public void Accelerate()
    {
        if (Stamina >= 10)
        {
            Speed += 10;
            Stamina -= 10;
        }
        else
        {
            Console.WriteLine(Name + " is too tired to accelerate!");
        }
    }

    public void MaintainSpeed()
    {
        Speed += 5;
        Stamina -= 5;
    }

    public void RandomBoost()
    {
        Random rand = new Random();
        int chance = rand.Next(1, 101);

        if (chance <= 20) // 20% boost chance
        {
            Console.WriteLine(Name + " got a TURBO BOOST!");
            Speed += 20;
        }
    }

    public void Move()
    {
        DistanceCovered += Speed;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("🏁 STREET RACER – THE FINAL LAP 🏁");
        Console.Write("Enter your racer name: ");
        string playerName = Console.ReadLine();

        Racer player = new Racer(playerName);
        Racer enemy = new Racer("Shadow Rider");

        int totalRounds = 5;

        for (int round = 1; round <= totalRounds; round++)
        {
            Console.WriteLine("\n--- ROUND " + round + " ---");

            Console.WriteLine("1. Accelerate (+10 speed, -10 stamina)");
            Console.WriteLine("2. Maintain Speed (+5 speed, -5 stamina)");
            Console.Write("Choose action: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                player.Accelerate();
            else
                player.MaintainSpeed();

            player.RandomBoost();
            player.Move();

            // Enemy AI
            Random rand = new Random();
            int enemyChoice = rand.Next(1, 3);

            if (enemyChoice == 1)
                enemy.Accelerate();
            else
                enemy.MaintainSpeed();

            enemy.RandomBoost();
            enemy.Move();

            Console.WriteLine("\n" + player.Name + " Distance: " + player.DistanceCovered);
            Console.WriteLine("Stamina: " + player.Stamina);
            Console.WriteLine(enemy.Name + " Distance: " + enemy.DistanceCovered);
        }

        Console.WriteLine("\n🏁 FINAL RESULT 🏁");

        if (player.DistanceCovered > enemy.DistanceCovered)
            Console.WriteLine(" YOU WIN THE RACE!");
        else if (player.DistanceCovered < enemy.DistanceCovered)
            Console.WriteLine(" You Lost! Shadow Rider wins.");
        else
            Console.WriteLine(" It's a Draw!");
    }
}

using System;

namespace sticks
{
    class Program
    {
        enum FirstMove
        {
            Player = 1,
            Computer
        }
        static void Main(string[] args)
        {
            int counter = 0;
            Console.Write("Введите количество палочек для игры: ");

            int sticks =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Кто ходит первым?\n 1 - игрок\n 2 - ИИ");
            FirstMove firstMove = (FirstMove)Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (sticks != 1)
            {
                PrintSticks(sticks);
                Console.WriteLine();
                if (firstMove == FirstMove.Player && counter % 2 ==  0)
                {
                    sticks -= UserMove();
                    counter++;
                    continue;
                }
                if (firstMove == FirstMove.Computer && counter % 2 == 1)
                {
                    sticks -= UserMove();
                    counter++;
                    continue;
                }
                Console.WriteLine();
                int tempII = MachineMove(sticks);
                Console.WriteLine(tempII == 1 ? $"ИИ убирает {tempII} палочку." : $"ИИ убирает {tempII} палочки.");
                sticks -= tempII;
                counter++;
            }
            PrintSticks(sticks);
            if (firstMove == FirstMove.Player)
                Console.WriteLine(counter % 2 == 0 ? "Вы проиграли =(" : "Вы победили!!!");               
            else
                Console.WriteLine(counter % 2 == 0 ? "Вы победили!!!" : "Вы проиграли =(");
            Console.ReadLine();
        }
        static void PrintSticks(int sticks)
        {
            Console.WriteLine($"Осталось палочек: {sticks}");
            for (int i = 0; i < sticks; i++)
            {
                Console.Write($" |");
            }
            Console.WriteLine();
        }
        static int MachineMove(int sticks)
        {
            Random rnd = new Random();
            if (sticks % 4 == 1)
                return rnd.Next(1, 4);
            else if (sticks % 4 == 0)
                return 3;
            else
                return sticks % 4 - 1;
        }
        static int UserMove()
        {
            Console.WriteLine("Сколько палочек убрать?(1-3) ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}

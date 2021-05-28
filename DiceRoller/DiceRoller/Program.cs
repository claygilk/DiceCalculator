using System;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Roll Some Dice!");

            UserInterface UI = new UserInterface();

            UI.MainMenu();
        }
    }
}

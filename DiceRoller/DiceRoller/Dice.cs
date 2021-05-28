using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DiceRoller
{
    public class Dice
    {
        public int SingleDie(int sizeOfDie)
        {
            
            Random diceRoller = new Random();
            return diceRoller.Next(1, sizeOfDie + 1);
        }

        public int Roll(int numberOfDice, int sizeOfDice)
        {
            List<int> validDice = new List<int>() { 4, 6, 8, 10, 12, 20, 100 };
            if (!validDice.Contains(sizeOfDice))
            {
                Console.WriteLine("Invalid Dice Size");
                return 0;
            }

            Random diceRoller = new Random();
            List<int> resultRolls = new List<int>();

            for (int i = 0; i < numberOfDice; i++)
            {
                resultRolls.Add(SingleDie(sizeOfDice));
            }

            int totalRoll = resultRolls.Sum();
            Console.Write(totalRoll + " (");

            for (int i = 0; i < resultRolls.Count; i++)
            {
                if (i < resultRolls.Count - 1)
                {
                    Console.Write(resultRolls[i] + " + ");
                }
                else
                {
                    Console.Write(resultRolls[i]);
                }

            }
            Console.Write(")");
            return totalRoll;
        }
    }
}

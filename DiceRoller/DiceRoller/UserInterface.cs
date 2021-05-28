using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller
{
    class UserInterface
    {

        // Method
        public void MainMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Enter Roll: (ex. 2d6 = Roll two six sided dice)");
                string input = Console.ReadLine();

                // Exit program if input is "q"
                if(input == "q")
                {
                    keepRunning = false;
                    break;
                }

                Calculator calc = new Calculator();

                List<string> operatorsAndOperands = calc.GetOperatorsAndOperands(input);

                List<string> rolledOperandsOperators = calc.RollDiceForOperands(operatorsAndOperands);

                int totalSum = calc.CalculateTotalOutput(rolledOperandsOperators);

                Console.Write(" = " + totalSum);


            }
        }
    }
}

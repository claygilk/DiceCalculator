using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DiceRoller
{
    public class Calculator
    {
        public List<string> GetOperatorsAndOperands(string userInput)
        {
            List<string> operands = new List<string>();

            char[] characters = userInput.ToCharArray();

            string unitOfInput = "";

            for (int i = 0; i < characters.Length; i++)
            {

                if (characters[i] == '+')
                {
                    operands.Add(unitOfInput);
                    operands.Add("+");
                    unitOfInput = "";
                }
                else if (characters[i] == '-')
                {
                    operands.Add(unitOfInput);
                    operands.Add("-");
                    unitOfInput = "";

                }
                else if (characters[i] == 'd')
                {
                    operands.Add(unitOfInput);
                    operands.Add("d");
                    unitOfInput = "";
                }
                else
                {
                    unitOfInput += characters[i];
                    if (i == characters.Length - 1)
                    {
                        operands.Add(unitOfInput);
                    }
                }

            }
            return operands;
        }

        public List<string> RollDiceForOperands(List<string> operandsAndOperators)
        {
            List<string> output = new List<string>();
            Dice dice = new Dice();

            // First pass to roll values
            for (int i = 0; i < operandsAndOperators.Count; i++)
            {
                if (operandsAndOperators[i] == "d")
                {
                    int resultOfRoll = dice.Roll(Convert.ToInt32(operandsAndOperators[i - 1]), Convert.ToInt32(operandsAndOperators[i + 1]));
                    output.Add(resultOfRoll.ToString());
                }
                else if (operandsAndOperators[i] == "+")
                {
                    output.Add("+");
                    Console.Write(" + ");
                }
                else if (operandsAndOperators[i] == "-")
                {
                    output.Add("-");
                    Console.Write(" - ");
                }
                else
                {
                    if (i == 0)
                    {
                        if (operandsAndOperators[i + 1] != "d")
                        {
                            output.Add(operandsAndOperators[i]);
                            Console.Write($" {operandsAndOperators[i]} ");
                        }
                    }
                    else if (i == operandsAndOperators.Count - 1)
                    {
                        if (operandsAndOperators[i - 1] != "d")
                        {
                            output.Add(operandsAndOperators[i]);
                            Console.Write($" {operandsAndOperators[i]} ");
                        }
                    }
                    else
                    {
                        if (operandsAndOperators[i - 1] != "d" && operandsAndOperators[i + 1] != "d")
                        {
                            output.Add(operandsAndOperators[i]);
                            Console.Write($" {operandsAndOperators[i]} ");
                        }
                    }
                }
            }
            return output;
        }

        public int CalculateTotalOutput(List<string> operandsOperators)
        {
            List<int> operandsAsInt = new List<int>();

            for (int i = 0; i < operandsOperators.Count; i++)
            {
                if(operandsOperators[i] != "+" && operandsOperators[i] != "+")
                {
                    if(i == 0)
                    {
                        operandsAsInt.Add(Convert.ToInt32(operandsOperators[i]));
                    }
                    else
                    {
                        if(operandsOperators[i-1] == "+")
                        {
                            operandsAsInt.Add(Convert.ToInt32(operandsOperators[i]));
                        }

                        if(operandsOperators[i-1] == "-")
                        {
                            operandsAsInt.Add(Convert.ToInt32(operandsOperators[i]) * -1);
                        }
                    }
                }

                
            }
            int total = operandsAsInt.Sum();

            return total;
        }
    }
}

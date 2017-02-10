using System;
using System.Globalization;

namespace CalculatorSpace
{
    class Calculator
    {
        static bool tryParseResult;

        //Starts here
        static void Main(string[] args)
        {
            WriteColor("Green", "Welcome to the calculator!\n\n");

            //Loop begins for iterative menu (until n becomes other than 1)
            int n = 1;
            //int inputVar;
            while (n == 1)
            {
                //The menu choices are written out
                Console.Write("\tMENU:\n" +
                    "\t1) Add\n" +
                    "\t2) Subtract\n" +
                    "\t3) Multiply\n" +
                    "\t4) Divide\n" +
                    "\t5) [CLEAR]\n" +
                    "\t6) [EXIT]\n\n");

                //Menu choice is requested and received, continues IF a successful parse to integer can be made
                Console.WriteLine("Choose a menu number.");

                char menuNum = 'X';

                //
                menuNum = GetMenuChoice(menuNum);

                if (menuNum > '0' && menuNum < '7')
                {
                    //Prepares and creates switch for choice branching
                    string inputText = "";
                    float num1 = 0F, num2 = 0F, resultNumber = 0F;

                    switch (menuNum)
                    {
                        case '1':
                            AddMethod(num1, num2, resultNumber, inputText);
                            break;
                        case '2':
                            SubMethod(num1, num2, resultNumber, inputText);
                            break;
                        case '3':
                            MultiMethod(num1, num2, resultNumber, inputText);
                            break;
                        case '4':
                            DivMethod(num1, num2, resultNumber, inputText);
                            break;
                        case '5':
                            Console.Clear();
                            break;
                        case '6':
                            /* Checks if you want to exit program, asks for (case-invariant) Y for yes
                            breaks the menu loop if yes by setting n to 0, then breaking from the case to the opened loop */
                            Console.WriteLine("Are you sure you want to exit? (Y/N)");

                            char exitKey = 'X';
                            //Neither Y nor N
                            while (exitKey != 'Y' && exitKey != 'N')
                            {
                                //Repeat user input while in the loop
                                exitKey = GetMenuChoice(exitKey);

                                //User hits Y
                                if (exitKey == 'Y')
                                {
                                    //n = 0 ends program loop
                                    n = 0;
                                    break;
                                }
                                //User hits N
                                else if (exitKey == 'N')
                                {
                                    break;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: That is not a menu choice. Try again.");
                }
            }
        }

        //METHOD FOR ADDING NUMBERS
        static void AddMethod(float addNumber1, float addNumber2, float resultNumber, string inputString)
        {
            //Asks for first number
            WriteColor("Green", "\nADDITION:\n");
            Console.WriteLine("Type a number ...");
            inputString = Console.ReadLine();
            tryParseResult = float.TryParse(inputString, NumberStyles.Float, CultureInfo.InvariantCulture, out addNumber1);
            Math.Round(addNumber1, MidpointRounding.ToEven);

            if (tryParseResult == false)
            {
                Console.WriteLine("ERROR: You either used invalid characters and/or your number is too large.");
            }

            else //If in allowed format, does same for second number with another format check
            {
                //Asks for second number
                Console.WriteLine($"Type a number to add to {addNumber1} ...");
                inputString = Console.ReadLine();
                tryParseResult = float.TryParse(inputString, NumberStyles.Float, CultureInfo.InvariantCulture, out addNumber2);
                Math.Round(addNumber2, MidpointRounding.ToEven);

                //When both numbers are ready, it goes on to calculate
                resultNumber = addNumber1 + addNumber2;
                Math.Round(resultNumber, MidpointRounding.ToEven);

                //Gives result to user
                Console.Write($"\n{addNumber1} + {addNumber2} = ");
                WriteColor("Green", $"{resultNumber}\n\n");
            }
        }

        //METHOD FOR SUBTRACTING NUMBERS
        static void SubMethod(float subNumber1, float subNumber2, float resultNumber, string inputString)
        {
            //Asks for first number, checks if it's in allowed format and gives error message if not
            WriteColor("Green", "\nSUBTRACTION:\n");
            Console.WriteLine("Type a number ...");
            inputString = Console.ReadLine();
            tryParseResult = float.TryParse(inputString, NumberStyles.Float, CultureInfo.InvariantCulture, out subNumber1);
            Math.Round(subNumber1, MidpointRounding.ToEven);

            if (tryParseResult == false)
            {
                Console.WriteLine("ERROR: You either used invalid characters and/or your number is too large.");
            }

            else //If in allowed format, does same for second number with another format check
            {
                Console.WriteLine($"Type a number to subtract from {subNumber1} ...");
                inputString = Console.ReadLine();
                tryParseResult = float.TryParse(inputString, NumberStyles.Float, CultureInfo.InvariantCulture, out subNumber2);
                Math.Round(subNumber2, MidpointRounding.ToEven);

                if (tryParseResult == false)
                {
                    Console.WriteLine("ERROR: You either used invalid characters and/or your number is too large.");
                }
                else
                {
                    //If both numbers were inputed correctly, goes on to process the calculation
                    resultNumber = subNumber1 - subNumber2;
                    Math.Round(resultNumber, MidpointRounding.ToEven);

                    //Gives result to user
                    Console.Write($"\n{subNumber1} - {subNumber2} = ");
                    WriteColor("Green", $"{resultNumber}\n\n");
                }
            }
        }

        //METHOD FOR MULTIPLYING NUMBERS
        static void MultiMethod(float multiNumber1, float multiNumber2, float resultNumber, string stringToFloat)
        {
            //Asks for first number, checks if it's in allowed format and gives error message if not
            WriteColor("Green", "\nMULTIPLICATION:\n");
            Console.WriteLine("Type a number ...");
            stringToFloat = Console.ReadLine();
            tryParseResult = float.TryParse(stringToFloat, NumberStyles.Float, CultureInfo.InvariantCulture, out multiNumber1);

            if (tryParseResult == false)
            {
                Console.WriteLine("ERROR: You either used invalid characters and/or your number is too large.");
            }

            else //If in allowed format, does same for second number with another format check
            {
                Console.WriteLine($"Type a number to multiply by {multiNumber1} ...");
                stringToFloat = Console.ReadLine();
                tryParseResult = float.TryParse(stringToFloat, NumberStyles.Float, CultureInfo.InvariantCulture, out multiNumber2);

                if (tryParseResult == false)
                {
                    Console.WriteLine("ERROR: You either used invalid characters and/or your number is too large.");
                }

                else
                {
                    //If both numbers were inputed correctly, goes on to process the calculation
                    resultNumber = multiNumber1 * multiNumber2;
                    Math.Round(resultNumber, MidpointRounding.ToEven);

                    //Gives result to user
                    Console.Write($"\n{multiNumber1} * {multiNumber2} = ");
                    WriteColor("Green", $"{resultNumber}\n\n");
                }
            }
        }

        //METHOD FOR DIVIDING NUMBERS
        static void DivMethod(float divNumber1, float divNumber2, float resultNumber, string stringToFloat)
        {
            //Asks for first number, checks if it's in allowed format and gives error message if not
            WriteColor("Green", "\nDIVISION:\n");
            Console.WriteLine("Type a number ...");
            stringToFloat = Console.ReadLine();
            tryParseResult = float.TryParse(stringToFloat, NumberStyles.Float, CultureInfo.InvariantCulture, out divNumber1);

            if (tryParseResult == false)
            {
                Console.WriteLine("ERROR: You either used invalid characters and/or your number is too large.");
            }

            else //If in allowed format, does same for second number with another format check
            {
                Console.WriteLine($"Type a number to divide {divNumber1} with ...");
                stringToFloat = Console.ReadLine();
                tryParseResult = float.TryParse(stringToFloat, NumberStyles.Float, CultureInfo.InvariantCulture, out divNumber2);

                if (tryParseResult == false)
                {
                    Console.WriteLine("ERROR: You either used invalid characters and/or your number is too large.");
                }

                else
                {
                    if (divNumber2 != 0)
                    {
                        /* If both numbers were inputed correctly (AND THEN the second number isn't zero)
                        it goes on to process calculation. */
                        resultNumber = divNumber1 / divNumber2;
                        Math.Round(resultNumber, MidpointRounding.ToEven);

                        //Gives result to user
                        Console.Write($"\n{divNumber1} / {divNumber2} = ");
                        WriteColor("Green", $"{resultNumber}\n\n");
                    }
                    else
                    {
                        //Calculation interrupted for division by zero
                        Console.WriteLine("\nERROR: You can't divide by zero!\n");
                    }
                }
            }
        }

        //Saves space by doing color formatting in custom method
        static void WriteColor(string color, string text)
        {
            Type type = typeof(ConsoleColor);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, color);
            Console.Write(text);
            Console.ResetColor();
        }

        //Gets general menu input for numbers, I use init 'X' to tell the method that it's needed
        static char GetMenuChoice(char inputValue)
        {
            bool isDone = false;

            while (!isDone)
            {
                //Loops input until it gets 1-6
                isDone = (!(inputValue >= '1' && inputValue <= '6') | !(inputValue == 'Y' || inputValue == 'N'))
                ? true : false;

                //Gets the input from user
                inputValue = Console.ReadKey(true).KeyChar;
                char.ToUpper(inputValue);
            }
            return inputValue;
        }
    }
}

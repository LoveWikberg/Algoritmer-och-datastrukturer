using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift3
{
    class Menu
    {
        public int PrintMenu(string[] inArray)
        {
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            int selectedItem = 0;
            ConsoleKeyInfo kb;

            Console.CursorVisible = false;

            //this will resise the console if the amount of elements in the list are too big
            if ((inArray.Length) > Console.WindowHeight)
            {
                throw new Exception("Too many items in the array to display");
            }

            /**
             * Drawing phase
             * */
            while (!loopComplete)
            {
                //This for method prints the array out
                PrintOptions(ConsoleColor.Gray, inArray, selectedItem);

                bottomOffset = Console.CursorTop;

                /*
                 * User input phase
                 * */

                kb = Console.ReadKey(true); //read the keyboard

                switch (kb.Key)
                { //react to input
                    case ConsoleKey.UpArrow:
                        if (selectedItem > 0)
                        {
                            selectedItem--;
                        }
                        else
                        {
                            selectedItem = (inArray.Length - 1);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selectedItem < (inArray.Length - 1))
                        {
                            selectedItem++;
                        }
                        else
                        {
                            selectedItem = 0;
                        }
                        break;

                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, topOffset);
                        PrintOptions(ConsoleColor.Green, inArray, selectedItem);
                        System.Threading.Thread.Sleep(500);
                        loopComplete = true;
                        break;
                }
                //Reset the cursor to the top of the screen
                Console.SetCursorPosition(0, topOffset);
            }
            //set the cursor just after the menu so that the program can continue after the menu
            Console.SetCursorPosition(0, bottomOffset);

            Console.CursorVisible = true;
            return selectedItem;
        }

        void PrintOptions(ConsoleColor backgroundColor, string[] inArray, int selectedItem)
        {
            for (int i = 0; i < inArray.Length; i++)
            {
                if (i == selectedItem)
                {
                    Console.BackgroundColor = backgroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("-" + inArray[i]);
                    Console.ResetColor();
                }
                else
                {//this section is what prints unselected items
                    Console.WriteLine("-" + inArray[i]);
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.ui
{
    class consoleUI
    {

        private void displayMenu()
        {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("10 - Display Menu");
        }
        public void run()
        {
            displayMenu();
            while (true)
            {
                Console.Write("Option:");
                try
                {
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 0: Environment.Exit(0); break;
                        case 10: displayMenu(); break;
                        default:
                            Console.WriteLine("Incorrect command!"); break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

        }
    }
}

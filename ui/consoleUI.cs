using NbaLeagueRomania.controller;
using NbaLeagueRomania.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.ui
{
    class consoleUI
    {
        Controller controller;

        public consoleUI(Controller controller)
        {
            this.controller = controller;
        }

        private void displayMenu()
        {
            Console.WriteLine("0 - Exit");
            Console.WriteLine("11 - Add Team");
            Console.WriteLine("12 - Display Teams");
            Console.WriteLine("21 - Add Player");
            Console.WriteLine("22 - Display All Players");
            Console.WriteLine("31 - Add Game");
            Console.WriteLine("32 - Display All Games");
            Console.WriteLine("41 - Add New Active Player");
            Console.WriteLine("42 - Display All Active Players");

        }

        private void addTeam()
        {
            Console.Write("Team name:");
            string teamName = Console.ReadLine();
            try
            {
                controller.AddTeam(teamName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void deleteTeam()
        {
            try
            {
                Console.Write("Enter team ID:");
                long id = long.Parse(Console.ReadLine());
                controller.DeleteGame(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void showAllTeams()
        {
            foreach(var t in controller.GetAllTeams())
                Console.WriteLine(t);
        }
        private void addPlayer()
        {
            try
            {
                Console.Write("Player name:");
                string name = Console.ReadLine();
                Console.Write("School name:");
                string schoolName = Console.ReadLine();
                Console.Write("Team id:");
                long teamID = long.Parse(Console.ReadLine());
                controller.AddNewPlayer(name, schoolName, teamID);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void deletePlayer()
        {
            try
            {
                Console.Write("Enter player ID:");
                long id = long.Parse(Console.ReadLine());
                controller.DeletePlayer(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void showAllPlayers()
        {
            foreach(var p in controller.GetAllPlayers())
                Console.WriteLine(p);
        }

        private void addGame()
        {
            try
            {
                Console.Write("First team id:");
                long teamID = long.Parse(Console.ReadLine());
                Console.Write("Second team id:");
                long teamID2 = long.Parse(Console.ReadLine());
                controller.AddGame(teamID, teamID2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void showAllGames()
        {
            foreach(var g in controller.GetAllGames())
                Console.WriteLine(g);
        }

        private void addActivePlayer()
        {
            try
            {
                Console.Write("Player id:");
                long playerID = long.Parse(Console.ReadLine());
                Console.Write("Game id:");
                long gameID = long.Parse(Console.ReadLine());
                Console.Write("Number of points:");
                int points = int.Parse(Console.ReadLine());
                Console.WriteLine("Player type:");
                Console.WriteLine("Press 1 for Participant");
                Console.WriteLine("Press 2 for Substitute");
                Console.Write("option:");
                int option = int.Parse(Console.ReadLine());
                Tip tip;
                if (option == 1)
                    tip = Tip.Participant;
                else
                    tip = Tip.Rezerva;
                controller.AddActivePlayer(playerID, gameID, points, tip);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void showAllActivePlayers()
        {
            foreach(var p in controller.GetAllActivePlayers())
                Console.WriteLine(p);
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
                        case 11: addTeam();break;
                        case 12: showAllTeams();break;
                        case 21: addPlayer();break;
                        case 22: showAllPlayers();break;
                        case 31: addGame();break;
                        case 32: showAllGames();break;
                        case 41: addActivePlayer();break;
                        case 42: showAllActivePlayers();break;
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

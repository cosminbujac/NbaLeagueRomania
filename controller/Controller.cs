using NbaLeagueRomania.entities;
using NbaLeagueRomania.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.controller
{
    class Controller
    {
        ActivePlayersService activePlayerService;
        TeamService teamService;
        PlayerService playerService;
        GameService gameService;

        public Controller(ActivePlayersService activePlayerService, TeamService teamService, PlayerService playerService, GameService gameService)
        {
            this.activePlayerService = activePlayerService;
            this.teamService = teamService;
            this.playerService = playerService;
            this.gameService = gameService;
        }

        public void AddTeam(string name)
        {
            teamService.AddTeam(new Team(name));
            
        }
        public void DeleteTeam(long id)
        {
            teamService.DeleteTeam(id);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return teamService.GetAllTeams();
        }

        public void AddNewPlayer(string nume, string scoala, long teamID)
        {
            Team team = teamService.GetOne(teamID);
            if (team == null)
                throw new Exception("The team doesn't exist!");
            playerService.AddPlayer(new Player(nume, scoala,team));
        }

        public void DeletePlayer(long id)
        {
            playerService.DeletePlayer(id);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return playerService.GetAllPlayers();
        }
        public List<Player> GetPlayersOfTeam(long teamID)
        {
            Team wantedTeam = teamService.GetOne(teamID);
            if (wantedTeam != null)
                return playerService.GetPlayersOfTeam(wantedTeam);
            else
                throw new Exception("The team doesn't exist!");
        }

        public void AddGame(long team1Id, long team2Id)
        {
            Team team1 = teamService.GetOne(team1Id);
            if (team1 == null)
                throw new Exception("There no team with that corresponds to the first ID!");
            Team team2 = teamService.GetOne(team2Id);
            if (team2 == null)
                throw new Exception("There no team with that corresponds to the second ID!");
            gameService.AddGame(new Game(team1,team2));
        }

        public void DeleteGame(long id)
        {
            gameService.DeleteGame(id);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return gameService.GetAll();
        }

        public List<Game> GetGamesBetweenDates(int month1,int year1, int month2, int year2)
        {
            if (month1 < 1 || month1 > 12)
                throw new Exception("Enter a valid first month!");
            if (month2 < 1 || month2 > 12)
                throw new Exception("Enter a valid second month!");
            DateTime start = new DateTime(year1, month1, 1);
            DateTime end = new DateTime(year2, month2, 1);
            return gameService.GetGamesBetween(start, end);

        }


        public void AddActivePlayer(long playerID, long gameID, int points, Tip tip)
        {
            if (playerService.GetOne(playerID) == null)
                throw new Exception("The player doesn't exist!");
            if (gameService.GetOne(gameID) == null)
                throw new Exception("The game doesn't exist!");
            if (activePlayerService.AddActivePlayer(new ActivePlayer(playerID, gameID, points, tip)) != null)
                throw new Exception("Active player already registered!");
        }

        public void DeleteActivePlayer(long playerID, long gameID)
        {
            if (playerService.GetOne(playerID) == null)
                throw new Exception("The player doesn't exist!");
            if (gameService.GetOne(gameID) == null)
                throw new Exception("The game doesn't exist!");
            activePlayerService.DeleteActivePlayer(new Tuple<long, long>(playerID, gameID));
        }

        public IEnumerable<ActivePlayer> GetAllActivePlayers()
        {
            return activePlayerService.GetAllActivePlayers();
        }

        public string GetScoreOfGame(long gameID)
        {
            Game game = gameService.GetOne(gameID);
            Team team1 = game.FirstTeam;
            int scoreT1=0, scoreT2=0;
            foreach (var x in activePlayerService.GetActivePLayersOfGame(gameID))
                if (playerService.GetOne(x.idJucator).Echipa.Equals(team1))
                    scoreT1++;
                else
                    scoreT2++;
            return game.ToString() + " | score: " + scoreT1 + " : " + scoreT2; 
        }
    }
}

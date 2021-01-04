using NbaLeagueRomania.entities;
using NbaLeagueRomania.service;
using System;
using System.Collections.Generic;
using System.Linq;
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
                throw new Exception("The team isn't registered!");
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
        public IEnumerable<Player> GetPlayersOfTeam(long teamID)
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
            if(team1==team2)
                throw new Exception("Team cannot play itself!");
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

        public IEnumerable<Player> getPlayersOfTeam(long teamId)
        {
            Team team = teamService.GetOne(teamId);
            if (team == null)
                throw new Exception("The team doesn't exist!");
            return playerService.GetPlayersOfTeam(team);
        }

        public List<Game> GetGamesBetweenDates(int month1,int year1, int month2, int year2)
        {
            if (month1 < 1 || month1 > 12)
                throw new Exception("Enter a valid first month!");
            if (month2 < 1 || month2 > 12)
                throw new Exception("Enter a valid second month!");
            DateTime start = new DateTime(year1, month1, 1);
            DateTime end = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
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
            if (game == null)
                throw new Exception("Game doesn't exist!");
            Team team1 = game.FirstTeam;
            int scoreT1=0, scoreT2=0;

            foreach (var x in activePlayerService.GetActivePlayersOfGame(gameID))
                if (playerService.GetOne(x.idJucator).Echipa.Equals(team1))
                    scoreT1+=x.nrPuncteInscrise;
                else
                    scoreT2+=x.nrPuncteInscrise;
            
            return game.ToString() + " | score: " + scoreT1 + " : " + scoreT2; 
        }

        public List<string> getActivePlayersOfGameAndTeam(long gameID,long teamID)
        {
            Game game = gameService.GetOne(gameID);

            if ( game == null)
                throw new Exception("Game doesn't exist!");
            if (teamService.GetOne(teamID) == null)
                throw new Exception("Team doesn't exist!");
            if (game.FirstTeam.ID != teamID && game.SecondTeam.ID != teamID)
                throw new Exception("The team doesn't play in this game!");

            List<string> players = new List<string>();
            players.Add("For team " + teamService.GetOne(teamID).Name + " :");

            activePlayerService.GetActivePlayersOfGame(gameID).ToList()
                .ForEach(x =>
                {
                    Player player = playerService.GetOne(x.idJucator);
                    if (player.Echipa.ID == teamID)
                        players.Add(player.Nume + " played as " + x.tip + " and scored " + x.nrPuncteInscrise + " points ");
                });
            return players;
        }
    }
}

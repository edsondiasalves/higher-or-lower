using System;
using System.Collections.Generic;
using System.Linq;

public class GameManager : IGameManager
{
    private List<Game> Games;
    
    public GameManager()
    {
        Games = new List<Game>();
    }

    public List<Game> ShowGames() => this.Games;

    public Game CreateNewGame()
    {
        Game newGame = new Game(this.Games.Count + 1);
        Games.Add(newGame);
        return newGame;
    }

    public List<Player> Guess(int GameId, int PlayerId, bool NextHiguerGuess){
        Game game = Games.FirstOrDefault(s => s.GameId == GameId);

        if (game == null){
            game = new Game(GameId);
            Games.Add(game);
        }

        return game.Guess(PlayerId, NextHiguerGuess);
    }
}
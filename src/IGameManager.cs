using System.Collections.Generic;

public interface IGameManager
{
    Game CreateNewGame();

    List<Player> Guess(int GameId, int PlayerId, bool NextHiguerGuess);

    List<Game> ShowGames();
}
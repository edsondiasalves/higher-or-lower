using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace tests
{
    [TestClass]
    public class GameManagerTest
    {
        public GameManager GameManager;

        public GameManagerTest(){
            GameManager = new GameManager();
        }

        [TestMethod]
        public void ShowGames_NoGames_ReturnEmtpyGameList()
        {
            //Act
            var games = GameManager.ShowGames();

            //Assert
            Assert.IsNotNull(games);
            Assert.AreEqual(0, games.Count);
        }

        [TestMethod]
        public void ShowGames_AddNewGame_ReturnOneGame()
        {
            //Arrange
            GameManager = new GameManager();
            GameManager.CreateNewGame();

            //Act
            var games = GameManager.ShowGames();

            //Assert
            Assert.IsNotNull(games);
            Assert.AreEqual(1, games.Count);
        }

        [TestMethod]
        public void CreateNewGame_NoPreviousGames_ReturnFirstGame()
        {
            //Arrange
            GameManager = new GameManager();

            //Act
            var game = GameManager.CreateNewGame();

            //Assert
            Assert.IsNotNull(game);
            Assert.AreEqual(1, game.GameId);
        }

        [TestMethod]
        public void CreateNewGame_TwoPreviousGames_ReturnThirdGame()
        {
            //Arrange
            GameManager = new GameManager();
            GameManager.CreateNewGame();
            GameManager.CreateNewGame();

            //Act
            var game = GameManager.CreateNewGame();

            //Assert
            Assert.IsNotNull(game);
            Assert.AreEqual(3, game.GameId);
        }
    
        [TestMethod]
        public void Guess_NoPreviousPlayers_ReturnNewPlayer()
        {
            //Arrange
            GameManager = new GameManager();
            GameManager.CreateNewGame();

            //Act
            var players = GameManager.Guess(1, 1, true);

            //Assert
            Assert.IsNotNull(players);
            Assert.AreEqual(1, players.Count);
            Assert.AreEqual(1, players.First().Id);
        }

        [TestMethod]
        public void Guess_OnePreviousPlayers_ReturnsSamePlayer()
        {
            //Arrange
            GameManager = new GameManager();
            GameManager.CreateNewGame();
            GameManager.Guess(1, 1, true);

            //Act
            var players = GameManager.Guess(1, 1, true);

            //Assert
            Assert.IsNotNull(players);
            Assert.AreEqual(1, players.Count);
            Assert.AreEqual(1, players.First().Id);
        }

        [TestMethod]
        public void Guess_OnePreviousPlayers_ReturnsNewPlayer()
        {
            //Arrange
            GameManager = new GameManager();
            GameManager.CreateNewGame();
            GameManager.Guess(1, 1, true);

            //Act
            var players = GameManager.Guess(1, 2, true);

            //Assert
            Assert.IsNotNull(players);
            Assert.AreEqual(2, players.Count);
            Assert.AreEqual(1, players.First().Attempts);
            Assert.AreEqual(1, players.Last().Attempts);
        }
    }
}   

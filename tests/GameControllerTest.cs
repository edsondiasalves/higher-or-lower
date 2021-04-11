using System.Collections.Generic;
using higher_or_lower.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace tests
{
    [TestClass]
    public class GameControllerTest
    {
        public GameController GameController;
        public Mock<IGameManager> GameManagerMock;

        public GameControllerTest(){
            GameManagerMock = new Mock<IGameManager>();
            GameController = new GameController(GameManagerMock.Object);
        }

        [TestMethod]
        public void ShowAllGames_NoGames_ReturnNullObject()
        {
            //Act
            var games = GameController.ShowAllGames();

            //Assert
            Assert.IsNull(games.Value);
        }

        [TestMethod]
        public void ShowAllGames_ThereIsGames_ReturnGames()
        {
            //Arrange
            List<Game> expectedGames = new List<Game>();
            expectedGames.Add(new Game(1));
            GameManagerMock.Setup(s => s.ShowGames()).Returns(expectedGames);

            //Act
            var returnedGames = GameController.ShowAllGames();

            //Assert
            Assert.IsNotNull(returnedGames);
            Assert.AreEqual(expectedGames.Count, (returnedGames.Value as List<Game>).Count);
        }

        [TestMethod]
        public void CreateNewGame_NoPreviousGames_ReturnNewGame() {
            Game expectedNewGame = new Game(1);
            GameManagerMock.Setup(s => s.CreateNewGame()).Returns(expectedNewGame);

            //Act
            var returnedNewGame = GameController.CreateNewGame();

            //Assert
            Assert.IsNotNull(returnedNewGame);
            Assert.AreEqual(expectedNewGame, returnedNewGame.Value);
        }
    }
}

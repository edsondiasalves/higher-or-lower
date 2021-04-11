using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class GameTest
    {
        public Game Game;
        public GameTest()
        {
        }

        [TestMethod]
        public void Constructor_PassingId_SetInitialConfiguration()
        {
            //Act
            Game = new Game(1);

            //Assert
            Assert.IsNotNull(Game);
            Assert.AreEqual(1, Game.GameId);
            Assert.AreEqual(1, Game.Moves);
            Assert.IsNotNull(Game.CurrentCard);
        }

        [TestMethod]
        public void DrawCard_FirstManualDrawn_IncrementsMoves()
        {
            //Arrange
            Game = new Game(1);

            //Act
            Game.DrawCard();

            //Assert
            Assert.AreEqual(2, Game.Moves);
        }

        [TestMethod]
        public void DrawCard_FirstManualDrawn_ChangeCurrentCard()
        {
            //Arrange
            Game = new Game(1);
            Card previousCard = Game.CurrentCard;

            //Act
            Game.DrawCard();
            Card currentCard = Game.CurrentCard;

            //Assert
            Assert.AreEqual(2, Game.Moves);
            Assert.AreNotEqual(currentCard, previousCard);
        }
    
        [TestMethod]
        public void DrawCard_LastCardDrawn_DoNotAllowDrawnMore()
        {
            //Arrange
            Game = new Game(1);
            Card previousCard = Game.CurrentCard;

            for(int i=0; i<51; i++){
                Game.DrawCard();
            }

            Assert.AreEqual(52, Game.Moves);

            //Act
            Game.DrawCard();

            //Assert
            Assert.AreEqual(52, Game.Moves);
        }

        [TestMethod]
        public void IsFinished_GameIsNotFinished_ReturnsFalse()
        {
            //Arrange
            Game = new Game(1);

            //Assert
            Assert.AreEqual(false, Game.IsFinished);
        }

        [TestMethod]
        public void IsFinished_GameIsNotFinished_ReturnsTrue()
        {
            //Arrange
            Game = new Game(1);

            for(int i=0; i<51; i++){
                Game.DrawCard();
            }

            //Assert
            Assert.AreEqual(true, Game.IsFinished);
        }
    }
}
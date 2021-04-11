using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace higher_or_lower.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private IGameManager GameManager;

        public GameController(IGameManager GameManager)
        {
            this.GameManager = GameManager;
        }

        /// <summary>
        ///     Shows all games
        /// </summary>
        /// <returns>
        ///     A list of Games object
        /// </returns>
        /// <response code="200">The list of existing games</response>
        /// <response code="500">Due an internal error it is not possible to show the list of games</response>
        [HttpGet]
        [Route("show")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ObjectResult ShowAllGames()
        {
            return Ok(GameManager.ShowGames());
        }

        /// <summary>
        ///     Create a new game
        /// </summary>
        /// <returns>
        ///     The new game
        /// </returns>
        /// <response code="200">New game created</response>
        /// <response code="500">The game was not create due an internal error</response>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ObjectResult CreateNewGame()
        {
            return Ok(GameManager.CreateNewGame());
        }

        /// <summary>
        ///     Guess if the value of the next card will be higher or lower the actual
        /// </summary>
        /// <param name="GameId"> The game Identification number.</param>
        /// <param name="PlayerId"> The player Identification number.</param>
        /// <param name="PlayerGuess"> True if you think the next card will be higher than the actual, otherwise false.</param>
        /// <remarks>
        ///     If the GameId provided not exist, a new Game will be created
        ///     
        ///     If the PlayerId proviced not exist, a new Player will be created
        ///     
        ///     If the game is finished, the votes will not be computed
        /// </remarks>
        /// <remarks>
        /// </remarks>
        /// <returns>
        ///     The current Score
        /// </returns>
        /// <response code="200">The current game score</response>
        /// <response code="500">Due an internal error it was not possible to guess</response>
        [HttpPost]
        [Route("guess/{GameId}/{PlayerId}/{PlayerGuess}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ObjectResult GuessNextCard(int GameId, int PlayerId, bool PlayerGuess)
        {
            return Ok(GameManager.Guess(GameId, PlayerId, PlayerGuess));
        }
    }
}

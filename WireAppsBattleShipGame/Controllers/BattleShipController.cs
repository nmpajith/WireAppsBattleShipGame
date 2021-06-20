using AutoMapper;
using DomainLayer.Models.Game;
using DomainLayer.Models.Panels;
using DomainLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WireAppsBattleShipGame.DataTranferObjects;
using WireAppsBattleShipGame.Extentions;

namespace WireAppsBattleShipGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleShipController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerService _playerService;
        private readonly IValidationService _validationService;
        private readonly ILogger<BattleShipController> _logger;

        public BattleShipController(ILogger<BattleShipController> logger, IMapper mapper
            , IPlayerService playerService, IValidationService validationService)
        {
            _logger = logger;
            _mapper = mapper;
            _playerService = playerService;
            _validationService = validationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PlayerDto), 201)]
        public IActionResult GetPlayers()
        {
            RealPlayer realPlayer = new RealPlayer("Ajith");
            AutoPlayer autoPlayer = new AutoPlayer("Computer");
            _playerService.PlaceShips(realPlayer);
            _playerService.PlaceShips(autoPlayer);
            var game = new Game { RealPlayer = realPlayer, AutoPlayer = autoPlayer };
            var gameDto = _mapper.Map<Game, GameDto>(game);
            return Ok(gameDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerDto), 201)]
        public IActionResult PlayRound([FromBody] GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var game = _mapper.Map<GameDto, Game>(gameDto);

            //check if the game is over and still firing
            var validationResponse = _validationService.ValidateGame(game);
            if (validationResponse.Success)
            {
                var coordinates = game.ManualShotCoordinates;
                //check here if the manual firing coordinates are valid. the real player fires at autoplayer gamepanel!
                validationResponse = _validationService.ValidateCoordinates(game.AutoPlayer.GamePanel, coordinates);
                if (validationResponse.Success)
                {
                    _playerService.PlayRound(game.RealPlayer, game.AutoPlayer, coordinates);
                    if (!game.AutoPlayer.HasLost) //If player 2 already lost, we can't let them take another turn.
                    {
                        coordinates = _playerService.GetCoordinatesForAutoFire(game.RealPlayer);
                        _playerService.PlayRound(game.AutoPlayer, game.RealPlayer, coordinates);
                    }
                }
                else
                {
                    game.RealPlayer.HitResult = validationResponse.Message;
                }
            }
            else
            {
                game.RealPlayer.HitResult = validationResponse.Message;
                game.AutoPlayer.HitResult = validationResponse.Message;
            }

            gameDto = _mapper.Map<Game, GameDto>(game);

            return Ok(gameDto);
        }
    }
}

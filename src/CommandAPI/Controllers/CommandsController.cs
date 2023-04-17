using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CommandsController> _logger;
        private readonly ICommandAPIRepo _repository;

        public CommandsController(ILogger<CommandsController> logger, ICommandAPIRepo repository)
        {
            _logger = logger;
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get()
        {
            IEnumerable<Command> commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        } 

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Command>> GetCommandById(int id)
        {
            Command commandItem = _repository.GetCommandById(id);
            if(commandItem==null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }   
    }
}

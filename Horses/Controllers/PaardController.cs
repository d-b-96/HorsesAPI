using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Horses.Models;
using Horses.Service;
using Microsoft.AspNetCore.Mvc;

namespace Horses.Controllers
{
    [Route("api/paarden")]
    [ApiController]
    public class PaardController : ControllerBase
    {
        private readonly IPaardService _paardService;

        public PaardController(IPaardService paardService)
        {
            _paardService = paardService;
        }

        // GET api/paarden
        [HttpGet]
        public ActionResult<IEnumerable<Paard>> Get()
        {
            return _paardService.GetAllPaarden().ToList();
        }

        // GET api/paarden/5
        [HttpGet("{id}")]
        public ActionResult<Paard> Get(int id)
        {
            return _paardService.GetPaardById(id);
        }
    }
}

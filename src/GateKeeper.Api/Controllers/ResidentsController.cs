using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Repositories.Interfaces;

namespace GateKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    public class ResidentsController : Controller
    {
        private readonly IResidentRepository _residentRepository;
        public ResidentsController(IResidentRepository residentRepository)
        {
            this._residentRepository = residentRepository;

        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var residents = await _residentRepository.GetAllAsync(x => true);
            return Ok(residents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var test = await _residentRepository.GetAllAsync(x => x.Id == id);
            return Ok(new Resident());
        }

        



    }
}

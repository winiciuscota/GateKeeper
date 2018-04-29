using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Repositories.Interfaces;
using GateKeeper.Api.ViewModels;
using AutoMapper;
using GateKeeper.Domain;

namespace GateKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    public class ResidentsController : Controller
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResidentsController(IResidentRepository residentRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._residentRepository = residentRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var residents = await _residentRepository.GetAllAsync(x => true);
            var result = _mapper.Map<IEnumerable<ResidentViewModel>>(residents);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resident = await _residentRepository.GetAsync(id);
            var result = _mapper.Map<ResidentViewModel>(resident);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResidentViewModel viewModel)
        {
            var resident = _mapper.Map<Resident>(viewModel);
            _residentRepository.Add(resident);
            await _unitOfWork.CompleteAsync();
            var result = _mapper.Map<ResidentViewModel>(resident);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ResidentViewModel viewModel)
        {
            var resident = await _residentRepository.GetAsync(id);
            _mapper.Map(viewModel, resident);
            await _unitOfWork.CompleteAsync();
            var result = _mapper.Map<ResidentViewModel>(resident);
            return Ok(result);
        }
    }
}

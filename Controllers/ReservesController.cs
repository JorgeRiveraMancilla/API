using API.Data;
using API.DTOs.PrimeraPeticion;
using API.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ReservesController : BaseApiController
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ReservesController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet("1")]
        public async Task<ActionResult<List<Object>>> PrimeraPeticion()
        {
            var users = await _dataContext.Users
                .Include(u => u.Reserves)
                .ThenInclude(r => r.AppBook)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            return Ok(users);
        }

        [HttpGet("2")]
        public async Task<ActionResult<List<Object>>> SegundaPeticion()
        {
            var users = await _dataContext.Users
                .Include(u => u.Reserves)
                .ThenInclude(r => r.AppBook)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            return Ok(users);
        }
    }
}
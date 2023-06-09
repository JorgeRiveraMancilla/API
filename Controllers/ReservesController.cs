using API.Data;
using API.DTOs.FirstRequest;
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
        public async Task<ActionResult<List<UserDto>>> FirstRequest()
        {
            var users = await _dataContext.Users
                .Include(u => u.Reserves)
                .ThenInclude(r => r.Book)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            DateTime currentDate = DateTime.Now;
            
            foreach (var user in users)
            {
                int quantityReservesCurrentMonth = 0;
                
                foreach (var reserve in user.Reserves)
                {
                    if (reserve.ReservedAt.Month == currentDate.Month && reserve.ReservedAt.Year == currentDate.Year)
                    {
                        quantityReservesCurrentMonth++;
                    }
                }

                user.QuantityReservesCurrentMonth = quantityReservesCurrentMonth;
            }

            return Ok(users);
        }

        [HttpGet("2")]
        public async Task SecondRequest()
        {
            
        }
    }
}
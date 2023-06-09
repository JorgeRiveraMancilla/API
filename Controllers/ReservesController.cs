using API.Data;
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
        public async Task<ActionResult<List<DTOs.FirstRequest.UserDto>>> FirstRequest()
        {
            var users = await _dataContext.Users
                .Include(u => u.Reserves)
                .ThenInclude(r => r.Book)
                .ProjectTo<DTOs.FirstRequest.UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            DateTime currentDate = DateTime.Now;
            
            foreach (var user in users)
            {
                int quantity = 0;
                DateTime maxDate = DateTime.MinValue;
                
                foreach (var reserve in user.Reserves)
                {
                    if (reserve.ReservedAt.Month == currentDate.Month && reserve.ReservedAt.Year == currentDate.Year)
                    {
                        quantity++;
                    }

                    if (maxDate < reserve.ReservedAt)
                    {
                        maxDate = reserve.ReservedAt;
                    }
                }

                user.QuantityReservesCurrentMonth = quantity;
                user.DateLastReserve = maxDate;
            }

            return Ok(users);
        }

        [HttpGet("2")]
        public async Task<ActionResult<List<DTOs.SecondRequest.BookDto>>> SecondRequest()
        {
            var books = await _dataContext.Books
                .Include(b => b.Reserves)
                .ThenInclude(r => r.User)
                .ProjectTo<DTOs.SecondRequest.BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            return Ok(books);
        }
    }
}
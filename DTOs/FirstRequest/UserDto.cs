namespace API.DTOs.FirstRequest
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public DateTime DateLastReserve { get; set; }
        public int QuantityReservesCurrentMonth { get; set; }
        public List<ReserveDto> Reserves { get; set; } = new();
    }
}
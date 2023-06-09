namespace API.DTOs.PrimeraPeticion
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public DateTime DateLastReserve { get; set; }
        public int QuantityReservesLastMonth { get; set; }
        public List<ReserveDto> Reserves { get; set; } = new();
    }
}
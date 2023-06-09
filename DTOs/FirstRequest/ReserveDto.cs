namespace API.DTOs.FirstRequest
{
    public class ReserveDto
    {
        public DateTime ReservedAt { get; set; }
        public BookDto Book { get; set; }
    }
}
namespace API.DTOs.SecondRequest
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ReserveDto> Reserves { get; set; } = new ();
    }
}
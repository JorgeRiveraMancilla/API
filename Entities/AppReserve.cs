namespace API.Entities
{
    public class AppReserve
    {
        public int Id { get; set; }
        public DateTime ReservedAt { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int BookId { get; set; }
        public AppBook Book { get; set; }
    }
}
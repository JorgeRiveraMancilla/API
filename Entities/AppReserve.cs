namespace API.Entities
{
    public class AppReserve
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppBookId { get; set; }
        public AppBook AppBook { get; set; }
    }
}
namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public List<AppReserve> Reserves { get; set; } = new();
    }
}
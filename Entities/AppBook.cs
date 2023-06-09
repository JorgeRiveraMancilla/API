namespace API.Entities
{
    public class AppBook
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AppReserve> Reserves { get; set; } = new();   
    }
}
namespace ApiProject.Models
{
    public class Singer
    {
        public int SingerId { get; set; }
        public string? SingerName { get; set; }
        public Albums? Albums { get; set; }
    }
}

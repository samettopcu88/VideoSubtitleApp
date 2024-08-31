namespace VideoSubtitleApp.Models
{
    public class Subtitle
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }


}

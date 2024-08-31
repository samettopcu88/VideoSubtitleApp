﻿namespace VideoSubtitleApp.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; } // Videonun yüklendiği dosya yolu
        public DateTime UploadDate { get; set; }
        public Subtitle Subtitle { get; set; }
    }


}

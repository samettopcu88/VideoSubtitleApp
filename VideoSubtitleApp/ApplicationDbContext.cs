using Microsoft.EntityFrameworkCore;
using VideoSubtitleApp.Models;

namespace VideoSubtitleApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Video ve Subtitle arasında birebir ilişki kuruluyor.
            modelBuilder.Entity<Video>()
                .HasOne(v => v.Subtitle)
                .WithOne(s => s.Video)
                .HasForeignKey<Subtitle>(s => s.VideoId);
        }
    }
}

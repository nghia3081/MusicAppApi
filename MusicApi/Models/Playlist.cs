namespace MusicApi.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            Songs = new HashSet<Song>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? IconUrl { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

using Newtonsoft.Json;

namespace MusicApi.Models
{
    public partial class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? ArtistId { get; set; }

        public virtual Artist? Artist { get; set; }
        [JsonIgnore]
        public virtual ICollection<Song> Songs { get; set; }
    }
}

using Newtonsoft.Json;

namespace MusicApi.Models
{
    public partial class Advertisement
    {
        public Advertisement()
        {
            Songs = new HashSet<Song>();
        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Content { get; set; }
        [JsonIgnore]
        public virtual ICollection<Song> Songs { get; set; }
    }
}

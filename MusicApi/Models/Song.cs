namespace MusicApi.Models
{
    public partial class Song
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? PlayUrl { get; set; }
        public int? Liked { get; set; }
        public Guid? PlaylistId { get; set; }
        public Guid? AlbumId { get; set; }
        public Guid? TopicId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? AdvertisementId { get; set; }

        public virtual Advertisement? Advertisement { get; set; }
        public virtual Album? Album { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Playlist? Playlist { get; set; }
        public virtual Topic? Topic { get; set; }
    }
}

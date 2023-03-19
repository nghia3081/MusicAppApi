using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Models;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongDevideController : ControllerBase
    {
        private readonly MusicApiContext _context;
        public SongDevideController(MusicApiContext musicApiContext)
        {
            _context = musicApiContext;
        }
        [HttpGet("GetAlbums")]
        public List<Album> GetAlbums() => _context.Albums.Include(a => a.Artist).ToList();
        [HttpGet("GetCategories")]
        public List<Category> GetCategories() => _context.Categories.ToList();
        [HttpGet("GetTopics")]
        public List<Topic> GetTopics() => _context.Topics.Include(t => t.Songs).ToList();
        [HttpGet("GetAdvertisements")]
        public List<Advertisement> GetAdvertisements() => _context.Advertisements.ToList();
        [HttpGet("GetPlaylists")]
        public List<Playlist> GetPlaylists() => _context.Playlists.ToList();

        [HttpPost("AddAdvertisement")]
        public Advertisement AddAdvertisement(Advertisement advertisement)
        {
            _context.Advertisements.Add(advertisement);
            _context.SaveChanges();
            return advertisement;
        }
        [HttpPost("AddAlbum")]
        public Album AddAlbum(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
            return album;
        }
        [HttpPost("AddArtist")]
        public Artist AddArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
            return artist;
        }
        [HttpPost("AddCategory")]
        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        [HttpPost("AddTopic")]
        public Topic AddTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            _context.SaveChanges();
            return topic;
        }
        [HttpPost("AddPlaylist")]
        public Playlist AddPlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return playlist;
        }
    }
}

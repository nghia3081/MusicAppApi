using Microsoft.AspNetCore.Mvc;
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
        public List<Album> GetAlbums() => _context.Albums.ToList(); 
        [HttpGet("GetCategories")]
        public List<Category> GetCategories() => _context.Categories.ToList(); 
        [HttpGet("GetTopics")]
        public List<Topic> GetTopics() => _context.Topics.ToList(); 
        [HttpGet("GetAdvertisements")]
        public List<Advertisement> GetAdvertisements() => _context.Advertisements.ToList(); 
        [HttpGet("GetPlaylists")]
        public List<Playlist> GetPlaylists() => _context.Playlists.ToList();

    }
}

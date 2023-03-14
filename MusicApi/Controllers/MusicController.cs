using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicApiContext _context;

        public MusicController(MusicApiContext musicApiContext)
        {
            _context = musicApiContext;
        }
        [HttpGet("GetAllSongs")]
        public List<Song> GetAllSong() => _context.Songs.ToList();

        [HttpGet("GetSongByTopic/{id}")]
        public List<Song> GetSongByTopic(Guid id)
        {
            return _context.Songs.Where(s => s.TopicId == id).ToList();
        }
        [HttpGet("GetSongByCategory/{id}")]
        public List<Song> GetSongByCategory(Guid id)
        {
            return _context.Songs.Where(s => s.CategoryId == id).ToList();
        }
        [HttpGet("GetSongByAlbum/{id}")]
        public List<Song> GetSongByAlbum(Guid id)
        {
            return _context.Songs.Where(s => s.AlbumId == id).ToList();
        }
        [HttpGet("GetSongByAdvertisement/{id}")]
        public List<Song> GetSongByAdvertisement(Guid id)
        {
            return _context.Songs.Where(s => s.AdvertisementId == id).ToList();
        }
        [HttpGet("GetSongByPlaylist/{id}")]
        public List<Song> GetSongByPlaylist(Guid id)
        {
            return _context.Songs.Where(s => s.PlaylistId == id).ToList();
        }
        [HttpGet("GetLovedSong")]
        public List<Song> GetLovedSong()
        {
            return _context.Songs.Where(s => s.Liked.HasValue).ToList();
        }
        [HttpGet("GetTopLovedSong")]
        public List<Song> GetTopLovedSong(int numberSong)
        {
            return _context.Songs.OrderByDescending(s => s.Liked).Take(numberSong).ToList();
        }
        [HttpPut("UpdateLiked/{id}")]
        public Song UpdateLiked(Guid id)
        {
            Song song = _context.Songs.Find(id) ?? throw new Exception("Not found this song");
            song.Liked += 1;
            _context.Songs.Update(song);
            _context.SaveChanges();
            return song;
        }
    }
}

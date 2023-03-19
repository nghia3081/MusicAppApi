using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Song> GetAllSong()
        {

            var result = _context.Songs.Include(s => s.Album).ThenInclude(a => a.Artist).AsEnumerable();
            return result;
        }

        [HttpGet("GetSongByTopic")]
        public List<Song> GetSongByTopic(Guid id)
        {
            return _context.Songs.Where(s => s.TopicId == id).Include(s => s.Album).ThenInclude(a => a.Artist).ToList();
        }
        [HttpGet("GetSongByCategory")]
        public List<Song> GetSongByCategory(Guid id)
        {
            return _context.Songs.Where(s => s.CategoryId == id).Include(s => s.Album).ThenInclude(a => a.Artist).ToList();
        }
        [HttpGet("GetSongByAlbum")]
        public List<Song> GetSongByAlbum(Guid id)
        {
            return _context.Songs.Where(s => s.AlbumId == id).Include(s => s.Album).ThenInclude(a => a.Artist).ToList();
        }
        [HttpGet("GetSongByAdvertisement")]
        public List<Song> GetSongByAdvertisement(Guid id)
        {
            return _context.Songs.Where(s => s.AdvertisementId == id).Include(s => s.Album).ThenInclude(a => a.Artist).ToList();
        }
        [HttpGet("GetSongByPlaylist")]
        public List<Song> GetSongByPlaylist(Guid id)
        {
            return _context.Songs.Where(s => s.PlaylistId == id).Include(s => s.Album).ThenInclude(a => a.Artist).ToList();
        }
        [HttpGet("GetLovedSong")]
        public List<Song> GetLovedSong()
        {
            return _context.Songs.Where(s => s.Liked.HasValue).Include(s => s.Album).ThenInclude(a => a.Artist).ToList();
        }
        [HttpGet("GetTopLovedSong")]
        public List<Song> GetTopLovedSong(int numberSong)
        {
            return _context.Songs.OrderByDescending(s => s.Liked).Include(s => s.Album).ThenInclude(a => a.Artist).Take(numberSong).ToList();
        }
        [HttpPut("UpdateLiked")]
        public Song UpdateLiked(Guid id)
        {
            Song song = _context.Songs.Find(id) ?? throw new Exception("Not found this song");
            song.Liked += 1;
            _context.Songs.Update(song);
            _context.SaveChanges();
            return song;
        }
        [HttpGet("GetSong")]
        public IEnumerable<Song> GetSong(string query)
        {
            if (string.IsNullOrEmpty(query)) return GetAllSong();
            var search = _context.Songs.Include(s => s.Album).ThenInclude(a => a.Artist)
                .Where(s => s.Name.Contains(query) || s.Album.Name.Contains(query) || s.Album.Artist.Name.Contains(query));
            return search ?? Enumerable.Empty<Song>();

        }
        [HttpPost("AddSong")]
        public Song AddSong(Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
            return song;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using d8APIDemo.Data;
using d8APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace d8APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private MusicDemoDBContext _context;

        public SongController(MusicDemoDBContext context)
        {
            _context = context;
        }
        // GET: api/Song
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _context.Songs;
        }

        // GET: api/Song/5
        [HttpGet("{id:int}", Name = "Get")]
        public Song Get(int id)
        {
            var song = _context.Songs.Find(id);
            return song;
        }

        // POST: api/Song
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            if(song.ID <= 0)
            {
                _context.Songs.Add(song); 
            }
            else
            {
                _context.Songs.Update(song);         
            }
            await _context.SaveChangesAsync();

            return Ok(song);
            
            
        }

        // PUT: api/Song/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] Song song)
        {
            if(id != song.ID)
            {
                return BadRequest();
            }

            var result = _context.Songs.FirstOrDefault(i => i.ID == id);

            result.Title = song.Title;
            result.Artist = song.Artist;

            _context.Update(result);
           await _context.SaveChangesAsync();

            return Ok(song);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var song = _context.Songs.Find(id);
            _context.Songs.Remove(song);

            await _context.SaveChangesAsync();
        }
    }
}

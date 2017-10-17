using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models.Entities;
using MusicStore.Models.ViewModels.Song;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Web.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Songs")]
    public class SongsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MusicStoreDbContext _dbContext;

        public SongsController(UserManager<ApplicationUser> userManager, MusicStoreDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetSongs")]
        public IEnumerable<Song> GetSongs()
        {
            var userId = _userManager.GetUserId(User);

            var songs = _dbContext.Songs
                .Include(song => song.Author)
                .Include(song => song.Category)
                .Where(song => song.UserId.Equals(userId))
                .OrderBy(song => song.Title)
                .ToList();

            return songs;
        }

        [HttpPost]
        [Route("CreateSong")]
        public IActionResult CreateSong(SongFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = _userManager.GetUserId(User);

            var newSong = new Song(viewModel, userId);

            _dbContext.Songs.Add(newSong);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
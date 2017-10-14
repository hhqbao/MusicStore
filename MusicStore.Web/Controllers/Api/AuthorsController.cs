using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Authors")]
    public class AuthorsController : Controller
    {
        private readonly MusicStoreDbContext _dbContext;

        public AuthorsController(MusicStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAuthors")]
        public IEnumerable<Author> GetAuthors()
        {
            return _dbContext.Authors.ToList();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly MusicStoreDbContext _dbContext;

        public CategoriesController(MusicStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
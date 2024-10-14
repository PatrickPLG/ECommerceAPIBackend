using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Models;
using ECommerceAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Favorite>> GetFavorites(int userId)
        {
            return await _favoriteRepository.GetFavorites(userId);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] Favorite favorite)
        {
            await _favoriteRepository.AddFavorite(favorite);
            return Ok("Favorite added");
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> RemoveFavorite(int userId, int productId)
        {
            await _favoriteRepository.RemoveFavorite(userId, productId);
            return Ok("Favorite removed");
        }
    }
}

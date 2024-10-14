using ECommerceAPI.Data;
using ECommerceAPI.Migrations;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetFavorites(int UserID);
        Task AddFavorite(Favorite favorite);

        Task RemoveFavorite(int UserID, int ProductID);
    }
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetFavorites(int UserID)
        {
            return await _context.Favorites.Where(f => f.UserID == UserID).ToListAsync();
        }

        public async Task AddFavorite(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavorite(int UserID, int ProductID)
        {
            var favorite = _context.Favorites.FirstOrDefault(f => f.UserID == UserID && f.ProductId == ProductID);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }
    }
}

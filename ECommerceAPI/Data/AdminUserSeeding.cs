using ECommerceAPI.Models;
using ECommerceAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Data
{
    public class AdminUserSeeding
    {
        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            var userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            var users = await userRepository.GetAllUsersAsync();
            if (!users.Any(u => u.Role == "Admin"))
            {
                CreatePasswordHash("AdminPassword123", out byte[] passwordHash, out byte[] passwordSalt);

                var adminUser = new User
                {
                    Username = "AdminUser",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = "Admin"
                };

                await userRepository.AddUser(adminUser);
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

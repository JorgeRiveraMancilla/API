using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext dataContext)
        {
            if (await dataContext.Users.AnyAsync())
            {
                return;
            }

            var usersData = await File.ReadAllTextAsync("Data/Seeder/UserSeedData.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var users = JsonSerializer.Deserialize<List<AppUser>>(usersData, options);

            foreach (var user in users)
            {
                await dataContext.Users.AddAsync(user);
            }

            await dataContext.SaveChangesAsync();
        }

        public static async Task SeedBooks(DataContext dataContext)
        {
            if (await dataContext.Books.AnyAsync())
            {
                return;
            }

            var bookData = await File.ReadAllTextAsync("Data/Seeder/BookSeedData.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var books = JsonSerializer.Deserialize<List<AppBook>>(bookData, options);

            foreach (var book in books)
            {
                await dataContext.Books.AddAsync(book);
            }

            await dataContext.SaveChangesAsync();
        }

        public static async Task SeedData(DataContext dataContext)
        {
            if (await dataContext.Users.AnyAsync() |  await dataContext.Books.AnyAsync())
            {
                return;
            }

            await SeedUsers(dataContext);
            await SeedBooks(dataContext);

            AppReserve reserve = new AppReserve
            {
                AppUser = await dataContext.Users.FindAsync(1),
                AppBook = await dataContext.Books.FindAsync(1)
            };

            await dataContext.Reserves.AddAsync(reserve);
            await dataContext.SaveChangesAsync();
        }
    }
}
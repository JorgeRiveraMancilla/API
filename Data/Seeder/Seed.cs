using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        private const int START_YEAR = 2023;
        private const int START_MONTH = 1;
        private const int START_DAY = 1;
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

            var booksData = await File.ReadAllTextAsync("Data/Seeder/BookSeedData.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var books = JsonSerializer.Deserialize<List<AppBook>>(booksData, options);

            foreach (var book in books)
            {
                await dataContext.Books.AddAsync(book);
            }

            await dataContext.SaveChangesAsync();
        }

        public static async Task SeedData(DataContext dataContext)
        {
            if (await dataContext.Reserves.AnyAsync())
            {
                return;
            }

            await SeedUsers(dataContext);
            await SeedBooks(dataContext);

            int quantityUsers = await dataContext.Users.CountAsync();
            int quantityBooks = await dataContext.Users.CountAsync();
            Random random = new Random();

            for (int userId = 1; userId < quantityUsers + 1; userId++)
            {
                AppUser user = await dataContext.Users.FindAsync(userId);
                int n = random.Next(quantityBooks);

                for (int j = 0; j < n; j++)
                {
                    int bookId = random.Next(1, quantityBooks + 1);
                    AppBook book = await dataContext.Books.FindAsync(bookId);

                    DateTime start = new DateTime(START_YEAR, START_MONTH, START_DAY);
                    int range = (DateTime.Today - start).Days;           
                    start = start.AddDays(random.Next(range));

                    AppReserve reserve = new AppReserve
                    {
                        ReservedAt = start,
                        User = user,
                        Book = book
                    };

                    await dataContext.Reserves.AddAsync(reserve);
                }
            }

            await dataContext.SaveChangesAsync();
        }
    }
}
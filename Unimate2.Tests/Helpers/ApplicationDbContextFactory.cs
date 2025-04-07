using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Tests.Helpers
{
    public static class ServerDbContextFactory
    {
        public static ServerDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ServerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ServerDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        public static void Destroy(ServerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

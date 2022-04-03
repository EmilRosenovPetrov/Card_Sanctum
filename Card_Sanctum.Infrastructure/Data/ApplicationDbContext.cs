namespace Card_Sanctum.Infrastructure.Data
{
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<BoosterPack> BoosterPacks { get; set; }
        
    }
}
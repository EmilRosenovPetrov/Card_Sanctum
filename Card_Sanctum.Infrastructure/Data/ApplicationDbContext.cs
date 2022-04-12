namespace Card_Sanctum.Infrastructure.Data
{
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Card_Sanctum.Infrastructure.InitialSeed;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trade>().HasKey(t => new { t.BoosterPackId, t.HobbyShopId });

            //modelBuilder.ApplyConfiguration(new InitialDataConfiguration<Card>(@"InitialSeed/cards.json"));

        }



        public DbSet<Card> Cards { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<BoosterPack> BoosterPacks { get; set; }

        public DbSet<HobbyShop> HobbyShops { get; set; }

        public DbSet<Trade> Trades { get; set; }
        
    }
}
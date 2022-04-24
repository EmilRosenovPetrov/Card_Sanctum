namespace Card_Sanctum.Infrastructure.Data
{
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Card_Sanctum.Infrastructure.InitialSeed;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
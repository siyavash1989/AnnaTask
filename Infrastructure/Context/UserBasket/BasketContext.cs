using Core.Entities.UserBasket;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.UserBasket
{
    public class BasketContext : DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
    }
}
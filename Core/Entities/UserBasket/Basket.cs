namespace Core.Entities.UserBasket
{
    public class Basket:BaseEntity
    {
        public Basket()
        {
        }

        public Basket(int id)
        {
            Id = id;
        }
        public virtual ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
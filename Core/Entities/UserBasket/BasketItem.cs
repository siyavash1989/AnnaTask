namespace Core.Entities.UserBasket
{
    public class BasketItem:BaseEntity
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ProdcutTitle { get; set; }
        public int ProductId { get; set; }
        public virtual Basket Basket { get; set; }
        public int BasketId { get; set; }
    }
}
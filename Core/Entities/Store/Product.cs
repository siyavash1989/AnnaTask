namespace Core.Entities.Store
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        public string PictureUrl { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public ProductBrand Brand { get; set; }
        public ProductCategory Category { get; set; }

    }
}
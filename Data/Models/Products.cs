namespace Data.Models
{
    public class Products : IDEntity
    {
        public Products()
        {
            Stocks = new Stocks();
        }
        public string Name { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public Stocks Stocks { get; set; }
    }
}
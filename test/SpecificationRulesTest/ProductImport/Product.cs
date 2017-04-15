namespace ProductImport
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public bool HasMinQuantity => Quantity > 4;
    }
}

using Model.Tables;

namespace Model.Register

{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Name { get; set; }  

        public long? CategoryId { get; set; }
        public long? SupplierId { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
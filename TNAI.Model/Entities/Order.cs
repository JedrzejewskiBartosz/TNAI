namespace TNAI.Model.Entities
{
    public class Order
    { 
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}

namespace ProductManager.Blazor.Dal.Entities
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public double Prix { get; set; }
    }
}

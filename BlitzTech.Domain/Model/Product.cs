namespace BlitzTech.Model
{
    public sealed class Product
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public bool IsActive { get; private set; }
        public string IdCategory { get; private set; } = "";
        public string urlImage { get; private set; } //Imagem do Produto
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
    }
}
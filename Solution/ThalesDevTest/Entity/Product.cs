namespace Entity
{
    public class Product
    {
        public int id { get; set; }

        public string title { get; set; }

        public double price { get; set; }

        public double tax { get; set; }

        public string description { get; set; }

        public List<string> images { get; set; }

        public DateTime creationAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Category category { get; set; }
    }
}

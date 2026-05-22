using System.Text.Json;
using MyApi.Models;

namespace MyApi.Repositories
{
    public class JsonRequestRepository : IRequestRepository
    {
        private readonly string _filePath = "products.json";

        private List<Product> LoadData()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Product>();
            }

            var json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<Product>>(json)
                   ?? new List<Product>();
        }

        private void SaveData(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(_filePath, json);
        }

        public List<Product> GetAll()
        {
            return LoadData();
        }

        public Product? GetById(Guid id)
        {
            return LoadData().FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            var products = LoadData();

            products.Add(product);

            SaveData(products);
        }

        public void Update(Product product)
        {
            var products = LoadData();

            var existing = products.FirstOrDefault(p => p.Id == product.Id);

            if (existing == null)
                return;

            existing.Name = product.Name;
            existing.Quantity = product.Quantity;
            existing.Price = product.Price;
            existing.Category = product.Category;

            SaveData(products);
        }

        public void Delete(Guid id)
        {
            var products = LoadData();

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);

                SaveData(products);
            }
        }
    }
}

using MyApi.Models;

public interface IProductRepository
{
    List<Product> GetAll();

    Product? GetById(Guid id);

    void Add(Product product);

    void Update(Product product);

    void Delete(Guid id);
}

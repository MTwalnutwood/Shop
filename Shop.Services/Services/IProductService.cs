using Shop.Entities.Entities;

namespace Shop.Services.Services;

public interface IProductService
{
    List<Product> GetAll();

    Product? GetById(int id);

    void Insert(Product product);

    void Update(Product product);

    void Delete(int id);
}
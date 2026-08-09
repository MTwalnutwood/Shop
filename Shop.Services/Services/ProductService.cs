using Shop.Data.Repository;
using Shop.Entities.Entities;

namespace Shop.Services.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _repository;

    public ProductService(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public List<Product> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public Product? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Insert(Product product)
    {
        _repository.Add(product);
    }

    public void Update(Product product)
    {
        _repository.Update(product);
    }

    public void Delete(int id)
    {
        var product = _repository.GetById(id);

        if (product != null)
        {
            _repository.Delete(product);
        }
    }
}
using Shop.Data.Repository;
using Shop.Entities.Entities;

namespace Shop.Services.Services;

public class ProductTypeService : IProductTypeService
{
    private readonly IGenericRepository<ProductType> _repository;

    public ProductTypeService(IGenericRepository<ProductType> repository)
    {
        _repository = repository;
    }

    public List<ProductType> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public ProductType? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Insert(ProductType productType)
    {
        _repository.Add(productType);
    }

    public void Update(ProductType productType)
    {
        _repository.Update(productType);
    }

    public void Delete(int id)
    {
        var productType = _repository.GetById(id);

        if (productType != null)
        {
            _repository.Delete(productType);
        }
    }
}
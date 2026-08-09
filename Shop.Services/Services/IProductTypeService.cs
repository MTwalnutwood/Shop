using Shop.Entities.Entities;

namespace Shop.Services.Services;

public interface IProductTypeService
{
    List<ProductType> GetAll();

    ProductType? GetById(int id);

    void Insert(ProductType productType);

    void Update(ProductType productType);

    void Delete(int id);
}
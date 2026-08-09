using Microsoft.AspNetCore.Mvc;
using Shop.Entities.Entities;
using Shop.Services.Services;

namespace Shop.Web.Controllers;

public class ProductTypesController : Controller
{
    private readonly IProductTypeService _productTypeService;

    public ProductTypesController(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    // GET: ProductTypes
    public IActionResult Index()
    {
        var productTypes = _productTypeService.GetAll();
        return View(productTypes);
    }

    // GET: ProductTypes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ProductTypes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProductType productType)
    {
        if (ModelState.IsValid)
        {
            _productTypeService.Insert(productType);

            return RedirectToAction(nameof(Index));
        }

        return View(productType);
    }
}

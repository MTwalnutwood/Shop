using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Persistence;
using Shop.Entities.Entities;
using Shop.Services.Services;

namespace Shop.Web.Controllers;

public class ProductsController : Controller
{
    private readonly ShopDbContext _context;
    private readonly IProductService _productService;

    public ProductsController(
        ShopDbContext context,
        IProductService productService)
    {
        _context = context;
        _productService = productService;
    }

    // GET: Products
    public IActionResult Index()
    {
        var products = _productService.GetAll();

        return View(products);
    }

    // GET: Products/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = _productService.GetById(id.Value);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        ViewData["ProductTypeId"] = new SelectList(
            _context.ProductTypes,
            "Id",
            "Name");

        return View();
    }

    // POST: Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(
        [Bind("Id,Name,Description,Price,ProductTypeId")] Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.Insert(product);

            return RedirectToAction(nameof(Index));
        }

        ViewData["ProductTypeId"] = new SelectList(
            _context.ProductTypes,
            "Id",
            "Name",
            product.ProductTypeId);

        return View(product);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        ViewData["ProductTypeId"] = new SelectList(
            _context.ProductTypes,
            "Id",
            "Name",
            product.ProductTypeId);

        return View(product);
    }

    // POST: Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(
        int id,
        [Bind("Id,Name,Description,Price,ProductTypeId")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _productService.Update(product);

            return RedirectToAction(nameof(Index));
        }

        ViewData["ProductTypeId"] = new SelectList(
            _context.ProductTypes,
            "Id",
            "Name",
            product.ProductTypeId);

        return View(product);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _productService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
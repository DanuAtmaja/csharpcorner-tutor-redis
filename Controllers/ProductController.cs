using Microsoft.AspNetCore.Mvc;
using TutorialRedis.CacheContract;
using TutorialRedis.Data;
using TutorialRedis.Model;

namespace TutorialRedis.Controllers;

public class ProductController: ControllerBase
{
    private readonly DbContextClass _dbContext;
    private readonly ICacheService _cacheService;

    public ProductController(DbContextClass dbContext, ICacheService cacheService)
    {
        _dbContext = dbContext;
        _cacheService = cacheService;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        var cacheData = _cacheService.GetData<IEnumerable<Product>>("product");
        if (cacheData != null)
        {
            return cacheData;
        }

        var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
        cacheData = _dbContext.Products.ToList();
        _cacheService.SetData<IEnumerable<Product>>("product", cacheData, expirationTime);
        return cacheData;
    }
}
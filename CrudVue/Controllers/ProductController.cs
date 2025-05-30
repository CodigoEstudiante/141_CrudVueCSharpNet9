using CrudVue.Data;
using CrudVue.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudVue.Controllers
{
    public class ProductController(AppDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var listProducts = _dbContext.Product.ToList().OrderBy(p => p.IdProduct);
            return Ok(listProducts);
        }

        [HttpPost]
        public IActionResult save([FromBody] Product value)
        {
            _dbContext.Product.Add(value);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult edit([FromBody] Product value)
        {
           var productFound =  _dbContext.Product.FirstOrDefault(p => p.IdProduct == value.IdProduct);

            if (productFound == null) return BadRequest();

            productFound.Name = value.Name;
            productFound.Price = value.Price;

            _dbContext.Product.Update(productFound);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult delete(int idProduct)
        {
            var productFound = _dbContext.Product.FirstOrDefault(p => p.IdProduct == idProduct);

            if (productFound == null) return BadRequest();

            _dbContext.Product.Remove(productFound);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

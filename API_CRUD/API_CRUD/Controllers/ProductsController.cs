using API_CRUD.Data;
using API_CRUD.Filter;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //when you apply the filter at the controller level it will be applied to all action methods in this controller only
    //[LogSensitiveAction]
    public class ProductsController : ControllerBase
    {
        //make a variable of AppDbContext class (Dependency Injection)
        private readonly AppDbContext context;
        //inject the context through constructor
        public ProductsController(AppDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<List<Product>> Getproducts()
        {
            var products = context.Products.ToList();
            return Ok(products);
        }
        [HttpGet]
        [Route("{id}")]
        //when you apply the filter at the action method level it will be applied to this action method only
        [LogSensitiveAction]
        public ActionResult<Product> GetbyId(int id)
        {
            var record = context.Products.Find(id);
            if(record == null)
                return NotFound();
            return Ok(record);
        }
        [HttpPost]
        public ActionResult<int> Createproduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return Ok(product.Id);
        }
        [HttpPut]
        public ActionResult Updateproduct(Product product)
        {
            var existingProduct = context.Products.Find(product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Sku = product.Sku;
            context.Products.Update(existingProduct);
            context.SaveChanges();
            return Ok(product.Id);
        }
        [HttpDelete]
        //send the id in the route ==> /Products/1
        //without send it in the route ==> /Products?id=1
        [Route("{id}")]
        public ActionResult Deleteproduct(int id)
        {
            var existingProduct = context.Products.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            context.Products.Remove(existingProduct);
            context.SaveChanges();
            return Ok();
        }
    }
}

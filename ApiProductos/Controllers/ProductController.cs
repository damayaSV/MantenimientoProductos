using Microsoft.AspNetCore.Mvc;
using ApiProductos.Entities;
using ApiProductos.BLL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            var BLL = new ProductBO();
            return BLL.GetAllProducts();
            
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var BLL = new ProductBO();
            return BLL.GetProduct(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            var BLL = new ProductBO();
            BLL.CreateProduct(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int Id, [FromBody] Product product)
        {
            var BLL = new ProductBO();
            BLL.UpdateProduct(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var BLL = new ProductBO();
            BLL.DeleteProduct(id);
        }
    }
}

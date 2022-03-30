using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: <ProductController>
        [HttpGet]
        public List<ProductModel> GetAll()
        {
            return new ProductModel().GetAll();
        }

        // GET <ProductController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return new ProductModel().Get(id);
        }

        // POST <ProductController>
        [HttpPost]
        public void Post([FromBody] ProductModel model)
        {
            new ProductModel().Add(model);
        }

        // PUT <ProductController>
        [HttpPut]
        public void Put([FromBody] ProductModel model)
        {
            new ProductModel().Update(model);
        }

        // DELETE <ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ProductModel().Delete(id);
        }
    }
}

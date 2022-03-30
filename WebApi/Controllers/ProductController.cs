using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Variable para recibir los parametros de configuración
        private readonly IConfiguration Configuration;

        public ProductController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: <ProductController>
        [HttpGet]
        public ApiResponse GetAll()
        {
            try
            {
                return new ApiResponse
                { 
                    IsSuccess = true,
                    Message = "Los productos se obtuvieron exitosamente",
                    Result = new ProductModel(Configuration.GetConnectionString("MySQLAmazonSeller")).GetAll()
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = $"Se generó un error al obtener los productos: {ex.Message}",
                    Result = null
                };
            }
        }

        // GET <ProductController>/5
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            try
            {
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "El producto se obtuvo exitosamente",
                    Result = new ProductModel(Configuration.GetConnectionString("MySQLAmazonSeller")).Get(id)
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = $"Se generó un error al obtener el producto: {ex.Message}",
                    Result = null
                };
            }
        }

        // POST <ProductController>
        [HttpPost]
        public ApiResponse Post([FromBody] ProductModel model)
        {
            try
            {
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "El producto se generó exitosamente",
                    Result = new ProductModel(Configuration.GetConnectionString("MySQLAmazonSeller")).Add(model)
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = $"Se generó un error al generar el producto: {ex.Message}",
                    Result = null
                };
            }
        }

        // PUT <ProductController>
        [HttpPut]
        public ApiResponse Put([FromBody] ProductModel model)
        {
            try
            {
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "El producto se actualizó exitosamente",
                    Result = new ProductModel(Configuration.GetConnectionString("MySQLAmazonSeller")).Update(model)
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = $"Se generó un error al actualizar el producto: {ex.Message}",
                    Result = null
                };
            }
        }

        // DELETE <ProductController>/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            try
            {
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "El producto se eliminó exitosamente",
                    Result = new ProductModel(Configuration.GetConnectionString("MySQLAmazonSeller")).Delete(id)
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = $"Se generó un error al eliminar el producto: {ex.Message}",
                    Result = null
                };
            }
        }
    }
}

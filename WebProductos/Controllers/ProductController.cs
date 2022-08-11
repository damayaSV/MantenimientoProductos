using Microsoft.AspNetCore.Mvc;
using WebProductos.Models;
using System.Net.Http;

namespace WebProductos.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ProductDTO>? products;


            var httpClient = new HttpClient();


            HttpResponseMessage response = httpClient.GetAsync("https://localhost:7163/api/Product").Result;
            products = response.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>().Result;

            return View(products);
        }


        public IActionResult AddOrEdit(int id=0)
        {
            ProductDTO? product = new ProductDTO();

            if (id !=0)
            {
                var httpClient = new HttpClient();


                HttpResponseMessage response = httpClient.GetAsync("https://localhost:7163/api/Product/" + id).Result;
                product = response.Content.ReadFromJsonAsync<ProductDTO>().Result;
                
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductDTO product)
        {

            if (product!=null)
            {
                var httpClient = new HttpClient();


                if (product.ProuctId ==0)
                {
                    //Insertamos
                    HttpResponseMessage response = httpClient.PostAsJsonAsync("https://localhost:7163/api/Product", product).Result;
                }else
                {
                    HttpResponseMessage response = httpClient.PutAsJsonAsync("https://localhost:7163/api/Product/"+ product.ProuctId, product).Result;
                }

               
            }
            return RedirectToAction("Index");
        }


       
        public ActionResult Delete(int id)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.DeleteAsync("https://localhost:7163/api/Product/" + id).Result;
            return RedirectToAction("Index");
        }



    }
}

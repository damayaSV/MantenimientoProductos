using ApiProductos.Entities;
using ApiProductos.DataAccess;

namespace ApiProductos.BLL
{
  public  class ProductBO
    {

        public Product? GetProduct(int id)
        {
            Product? product = null;

            using (var db= new EmpresaContext())
            {
                product = (from p in db.Product where p.ProuctId == id select p).FirstOrDefault();
            }

            return product;
        }

        public List<Product>  GetAllProducts()
        {
           List<Product>? products = null;

            using (var db = new EmpresaContext())
            {
                products = (from p in db.Product select p).ToList();
            }

            return products;
        }

        public void CreateProduct(Product product )
        {
            using (var db = new EmpresaContext())
            {
                db.Add<Product>(product);
                db.SaveChanges();
            }
        }


        public void UpdateProduct(Product product)
        {
            //verificar si existe
            Product? productA = GetProduct(product.ProuctId);

            if (productA != null)
            {
                using (var db = new EmpresaContext())
                {
                    db.Update<Product>(product);
                    db.SaveChanges();
                }

                
            }
        }


        public void DeleteProduct( int Id)
        {
            using(var bd = new EmpresaContext())
            {
                //verificar si existe
                Product? product = GetProduct(Id);

                if (product !=null)
                {
                    bd.Remove<Product>(product);
                    bd.SaveChanges();
                }
            }
        }
    }
}

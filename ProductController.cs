public class ProductController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public Product DoWork(int id)
        {
            for (int x = 0; x <= 3; x++)
            {
                for (int i = 0; i != 1000000000; ++i)
                    ;
            }

            return products.FirstOrDefault((p) => p.Id == id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = DoWork(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }

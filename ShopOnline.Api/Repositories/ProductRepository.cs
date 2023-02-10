using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.shopOnlineDbContext.ProductCategories.ToListAsync();

            return categories;

        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
            //SingleOrDefaultAsync method wordt gebruikt om de productcatergory.id te vinden met de overeenkomende id 
            // De lambda-uitdrukking c => c.Id == id kan worden gelezen als: "Gegeven een invoer c van het type ProductCategory, 
            // geef true terug als c.Id gelijk is aan id, anders geef false terug."     
        }


        public async Task<Product> GetItem(int id)
        {
            var product = await shopOnlineDbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        { 
            var products = await this.shopOnlineDbContext.Products.ToListAsync();

            return products;
        }
    }
}

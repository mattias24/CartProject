using CartProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CartProject.Data
{
    public class SeedData
    {
        public static void SeedDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                Category fruits = new Category { Name = "Fruits", Slug ="fruits" };
                Category shirts = new Category { Name = "shirts", Slug="shirts" };

                context.Products.AddRange(
                     new Products
                     {
                         Name = "Apples",
                         Slug="apples",
                         Description="Awful and rotten",
                         Price = 1.50M,
                         Category = fruits,
                         Image ="apples.png"
                     },
                      new Products
                      {
                          Name = "Lemons",
                          Slug= "lemons",
                          Description = "Sour",
                          Price = 1.30M,
                          Category = fruits,
                          Image="lemons.png"
                          
                      },
                       new Products
                      {
                          Name = "Pinapple",
                          Slug= "pineapple",
                          Description = "Fresh",
                          Price = 1.10M,
                          Category = fruits,
                          Image="pineapple.png"
                          
                      },
                       new Products
                      {
                          Name = "T-shirt",
                          Slug= "t-shirt",
                          Description = "Plain t-shirt",
                          Price = 3.20M,
                          Category = shirts,
                          Image="tshirt.png"
                          
                      },
                      new Products
                      {
                          Name = "Yellow Shirt",
                          Slug= "yellowshirt",
                          Description = "Yellow shirt",
                          Price = 4.00M,
                          Category = shirts,
                          Image="yellow.png"
                          
                      },
                      new Products
                      {
                          Name = "Green t-shirt",
                          Slug= "greentshirt",
                          Description = "Green like leafs",
                          Price = 1.10M,
                          Category = shirts,
                          Image="green.png"
                          
                      }

                    );
                context.SaveChanges();
            }
        }

    }
}

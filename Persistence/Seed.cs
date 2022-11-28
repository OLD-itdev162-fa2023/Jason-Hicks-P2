using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.Foods.Any())
            {
                var Foods = new List<Food>
                {
                    new Food {
                        FoodName = "Hamburger",
                        Body = "Contains Beef, Onion, Colby Jack Cheese, Garlic, Basil, Oregano",
                        Price = 5 
                    },
                    new Food {
                        FoodName = "Spaghetti",
                        Body = "Contains Italian Sausage, Onion, Garlic, Pasta Sauce",
                        Price = 4
                    },
                    new Food {
                        FoodName = "Hamburger",
                        Body = "Contains Lettuce, Arugula, Orange, Olives, Pine Nuts",
                        Price = 3
                    },
                };

                context.Foods.AddRange(Foods);
                context.SaveChanges();
            }
        }
    }
}
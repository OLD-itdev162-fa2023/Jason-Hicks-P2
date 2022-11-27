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
            if(!context.Posts.Any())
            {
                var Posts = new List<Post>
                {
                    new Post {
                        Title = "Frist post",
                        Body = "dsjf;lksahf;klsdahf;l",
                        Date = DateTime.Now.AddDays(-10)
                    },
                    new Post {
                        Title = "Second post",
                        Body = "dsjf;lksahf;klsdahf;l",
                        Date = DateTime.Now.AddDays(-10)
                    },
                    new Post {
                        Title = "Third Post",
                        Body = "dsjf;lksahf;klsdahf;l",
                        Date = DateTime.Now.AddDays(-10)
                    },
                };

                context.Posts.AddRange(Posts);
                context.SaveChanges();
            }
        }
    }
}
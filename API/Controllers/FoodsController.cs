using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly DataContext context;
        public FoodsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetFoods")]
        public ActionResult<List<Food>> Get()
        {
            return this.context.Foods.ToList();
        }

        [HttpGet("{id}", Name = "GetById" )]
        public ActionResult<Food> GetById(Guid id)
        {
            var food = this.context.Foods.Find(id);
            if (food is null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [HttpPost(Name = "Create")]
        public ActionResult<Food> Create([FromBody]Food request)
        {
            var food = new Food 
            {
                Id = request.Id,
                FoodName = request.FoodName,
                Body = request.Body,
                Price = request.Price
            };

            context.Foods.Add(food);
            var success = context.SaveChanges() > 0;

            if (success)
            {
                return Ok(food);
            }

            throw new Exception("Error creating food");
        }

        [HttpPut(Name = "UPdate")]
        public ActionResult<Food> Update([FromBody]Food request)
        {
            var food = context.Foods.Find(request.Id);
            if (food == null)
            {
                throw new Exception("Could not find food");
            }

            food.FoodName = request.FoodName != null ? request.FoodName : food.FoodName;
            food.Body = request.Body != null ? request.Body : food.Body;
            food.Price = request.Price != 0 ? request.Price : food.Price;

            var success = context.SaveChanges() > 0;

            if(success)
            {
                return Ok(food);
            }

            throw new Exception("Error updating food");
        }
    }
}
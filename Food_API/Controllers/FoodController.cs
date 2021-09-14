using Food_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Food_API.Controllers
{
    public class FoodController : ApiController
    {
        FoodEntities Context = new FoodEntities();

        public List<Food_Data> GetAll()
        {
            List<Food_Data> Foods = Context.Food_Data.ToList();
            return Foods;
        }

        public Food_Data GetOne(int id)
        {
            Food_Data Food = Context.Food_Data.FirstOrDefault(f => f.ID == id);
            return Food;
        }

        public IHttpActionResult PostFood(Food_Data Food)
        {
            if (Food != null)
            {
                Context.Food_Data.Add(Food);
                Context.SaveChanges();
                string url = "https://localhost:44385/api/Food/" + Food.ID;
                return Created<string>(url, "add successfuly");
            }
            else
            {
                return BadRequest("not added");
            }
        }

        public IHttpActionResult PutFood(int id, Food_Data Food)
        {
            Food_Data FoodOld = Context.Food_Data.Find(id);
            FoodOld.Food_Name = Food.Food_Name;
            FoodOld.img = Food.img;
            FoodOld.Type = Food.Type;
            FoodOld.Description = Food.Description;
            Context.SaveChanges();
            return Ok<Food_Data>(FoodOld);
        }

        public IHttpActionResult DeleteFood(int id)
        {
            Food_Data FoodDelete = Context.Food_Data.Find(id);
            Context.Food_Data.Remove(FoodDelete);
            Context.SaveChanges();
            return Ok();

        }
        // PUT: api/Food/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Food/5
        //public void Delete(int id)
        //{
        //}
        // POST: api/Food
        //public void Post([FromBody]string value)
        //{
        //}
    }
}

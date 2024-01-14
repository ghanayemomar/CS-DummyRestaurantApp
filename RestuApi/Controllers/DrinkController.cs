using Contracts.DTO;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DrinkController : ControllerBase
    {   //
        private readonly IDrink _drink;
        //
        public DrinkController(IDrink drink)
        {
            _drink = drink;
        }
        //
        [HttpPost]
        public void CreateDrink([FromBody]CreateDrinkDTO drink)
        {
            _drink.CreateDrink(drink);
        }
        //
        [HttpGet]
        public IActionResult RetriveAllDrinks()
        {
            var result = _drink.RetriveAllDrinks();
            var finalResult = new DrinkWithTotalPriceDTO()
            {
                Drinks = result,
                TotalPrice = result.Select(d => d.Price).Sum(),
            };
            return Ok(finalResult);
        }
        //
        [HttpGet]
        public IActionResult RetriveDrinkById(int id)
        {
            var drink = _drink.RetriveDrinkById(id);
            if (drink == null)
            {
                return NotFound(); 
            }
            return Ok(drink);
        }
        //
        [HttpDelete]
        public IActionResult DeleteDrink(int id)
        {
            var success = _drink.DeleteDrink(id);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public void UpdateDrink([FromBody] UpdateDrinkDTO drink)
        {
            _drink.UpdateDrink(drink);
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace WillocksHouse.Cheffia.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController
    {
        private readonly ILogger<RestaurantController> _logger;
        //private readonly IRestaurantUseCase _restaurantUseCase;

        public RestaurantController(ILogger<RestaurantController> logger/*, IRestaurantUseCase restaurantUseCase*/)
        {
            _logger = logger;
           //_restaurantUseCase = restaurantUseCase;
        }

        //[HttpPost("/create")]
        //public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantInputDto restaurantInput)
        //{
        //    try
        //    {
        //        var input = await _restaurantUseCase.CreateRestaurant(restaurantInput);

        //        if (!input.IsValid)
        //        {
        //            var getErrorMessages = input.ErrorMessages;
        //            return BadRequest(getErrorMessages);
        //        }

        //        var getResults = input.GetResult();
        //        return Ok(getResults);
        //    }
        //    catch (Exception error)
        //    {
        //        _logger.LogError(
        //                               $"RestaurantController::CreateRestaurant - An Error occurred while creating the restaurant - error: {error}",
        //                                                  error.Message);
        //        return StatusCode(500, "An Error occurred while creating the restaurant");
        //    }
        //}
    }
}

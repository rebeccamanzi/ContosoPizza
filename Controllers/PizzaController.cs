// A controller is a public class with one or more public methods known as actions. By convention, a controller is placed in the project root's Controllers directory. The actions are exposed as HTTP endpoints inside the web API controller.

// this class derives from ControllerBase, the base class for working with HTTP requests in ASP.NET Core.

using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
//  Because this controller class is named PizzaController, this controller handles requests to https://localhost:{PORT}/pizza.

public class PizzaController : ControllerBase
{
  public PizzaController()
  {
  }

  [HttpGet]
  public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();
  // Returns an ActionResult instance of type List<Pizza>. The ActionResult type is the base class for all action results in ASP.NET Core.
  // Queries the service for all pizza and automatically returns data with a Content-Type value of application/json.


  [HttpGet("{id}")]
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza == null)
      return NotFound();

    return pizza;
  }

  [HttpPost]
  public IActionResult Create(Pizza pizza)
  {
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);

    // The first parameter in the CreatedAtAction method call represents an action name. The nameof keyword is used to avoid hard-coding the action name. CreatedAtAction uses the action name to generate a location HTTP response header with a URL to the newly created pizza
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Pizza pizza)
  {
    if (id != pizza.Id)
      return BadRequest();

    var existingPizza = PizzaService.Get(id);
    if (existingPizza is null)
      return NotFound();

    PizzaService.Update(pizza);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza is null)
      return NotFound();

    PizzaService.Delete(id);

    return NoContent();
  }
}

// Each ActionResult instance used in the preceding action is mapped to the corresponding HTTP status code

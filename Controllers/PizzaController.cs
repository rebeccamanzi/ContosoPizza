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
  // Responds only to the HTTP GET verb, as denoted by the[HttpGet] attribute.
  // Returns an ActionResult instance of type List<Pizza>. The ActionResult type is the base class for all action results in ASP.NET Core.
  // Queries the service for all pizza and automatically returns data with a Content-Type value of application/json.
  public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza == null)
      return NotFound();

    return pizza;
  }

  // POST action

  // PUT action

  // DELETE action
}
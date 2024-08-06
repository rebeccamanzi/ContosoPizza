using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace ContosoPizza.Models;

public class Topping
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public decimal Calories { get; set; }

    [JsonIgnore]
    // This attribute prevents Topping entities from including the Pizzas property when the web API code serializes the response to JSON. Without this change, a serialized collection of toppings would include a collection of every pizza that uses the topping. Each pizza in that collection would contain a collection of toppings, which each would again contain a collection of pizzas. This type of infinite loop is called a circular reference and can't be serialized.
    public ICollection<Pizza>? Pizzas { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class Pizza
// The model contains properties that represent the characteristics of a pizza. The model is used to pass data in the web API and to persist pizza options in the data store.
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public Sauce? Sauce { get; set; }

    public ICollection<Topping>? Toppings { get; set; }
}
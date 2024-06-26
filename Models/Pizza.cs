namespace ContosoPizza.Models;

public class Pizza
// The model contains properties that represent the characteristics of a pizza. The model is used to pass data in the web API and to persist pizza options in the data store.
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
}
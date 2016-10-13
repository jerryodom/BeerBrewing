using System;

public abstract class Recipe
{
    public string Name { get; set; }
    public Brewer BrewerName { get; set; }
    public Recipe()
	{
	}
}

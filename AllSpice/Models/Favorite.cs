namespace AllSpice.Models;

public class Favorite
{
  public int Id { get; set; }
  public string AccountId { get; set; }
  public int RecipeId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}

public class RecipeFavorite : Profile
{
  public int FavoriteId { get; set; }
}

public class MyFavoriteRecipes : Recipe
{
  public int FavoriteId { get; set; }
}

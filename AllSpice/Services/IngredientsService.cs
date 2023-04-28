namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal Ingredient GenerateIngredients(Ingredient ingredientData)
  {
    Ingredient ingredient = _repo.InsertIngredients(ingredientData);
    return ingredient;
  }

  internal List<Ingredient> GetRecipeIngredients(int recipeId)
  {
    List<Ingredient> ingredients = _repo.GetRecipeIngredients(recipeId);
    return ingredients;
  }

  internal string RemoveIngredient(int ingredientId)
  {
    _repo.RemoveIngredient(ingredientId);
    return "The ingredient was destroyed, cast into the mouth of the dog waiting eagerly by the counter.";
  }
}

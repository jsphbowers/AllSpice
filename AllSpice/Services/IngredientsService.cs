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
}

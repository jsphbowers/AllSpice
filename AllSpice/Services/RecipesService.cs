namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal string DeleteRecipe(int recipeId)
  {
    Recipe doomedRecipe = this.GetOneRecipe(recipeId);
    _repo.DeleteRecipe(recipeId);

    return $"The recipe {doomedRecipe.Title} has been cast into the fires of mount doom";
  }

  internal Recipe EditRecipe(Recipe recipeData, int recipeId)
  {
    Recipe originalRecipe = GetOneRecipe(recipeId);

    originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
    originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
    originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
    originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;

    _repo.EditRecipe(originalRecipe);

    originalRecipe.UpdatedAt = DateTime.Now;

    return originalRecipe;
  }

  internal Recipe GenerateRecipe(Recipe recipeData)
  {
    int id = _repo.GenerateRecipe(recipeData);
    Recipe recipe = this.GetOneRecipe(id);
    return recipe;
  }

  internal Recipe GetOneRecipe(int recipeId)
  {
    Recipe recipe = _repo.GetOneRecipe(recipeId);
    if (recipe == null)
    {
      throw new Exception($"THIS RECIPE ID IS NON EXISTENT {recipeId}");
    }
    return recipe;
  }

  internal List<Recipe> GetRecipes()
  {
    List<Recipe> recipes = _repo.GetRecipes();
    return recipes;
  }
}

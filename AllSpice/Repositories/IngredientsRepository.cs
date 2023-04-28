namespace AllSpice.Repositories;

public class IngredientsRepository
{

  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }



  internal Ingredient InsertIngredients(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO ingredients
    (name, quantity, recipeId)
    VALUES
    (@name, @quantity, @recipeId);

    SELECT
    *
    FROM ingredients
    WHERE ingredients.id = LAST_INSERT_ID();";
    Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();

    return ingredient;
  }

  internal List<Ingredient> GetRecipeIngredients(int recipeId)
  {
    string sql = @"
    SELECT
    *
    FROM ingredients
    WHERE ingredients.recipeId = @recipeId;";
    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    return ingredients;
  }
}

namespace AllSpice.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
    _db.Execute(sql, new { recipeId });
  }

  internal void EditRecipe(Recipe originalRecipe)
  {
    string sql = @"
UPDATE recipes 
SET
title = @Title,
instructions = @Instructions,
category = @Category,
img = @Img
WHERE id = @Id
    ;";

    _db.Execute(sql, originalRecipe);
  }

  internal int GenerateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes(
      title, instructions, img, category, creatorId
    )
    values(
      @Title, @Instructions, @Img, @Category, @creatorId
    );
    SELECT LAST_INSERT_ID();";

    int id = _db.ExecuteScalar<int>(sql, recipeData);

    return id;
  }

  internal Recipe GetOneRecipe(int recipeId)
  {
    // string sql = @"
    // SELECT 
    // rec.*, acct.*
    // FROM recipes rec
    // JOIN accounts acct ON rec.creatorId = acct.id
    // ;";

    string sql = @"
    SELECT 
    rec.*, acct.*
    FROM recipes rec
    JOIN accounts acct ON acct.id = rec.creatorId
    WHERE rec.id = @recipeId
    ;";

    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
    return recipe;
  }

  internal List<Recipe> GetRecipes()
  {
    string sql = @"
    SELECT
    *
    FROM
    recipes
    ;";

    List<Recipe> recipes = _db.Query<Recipe>(sql).ToList();
    return recipes;
  }
}

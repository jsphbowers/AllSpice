namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth;

  public RecipesController(RecipesService recipesService, Auth0Provider auth)
  {
    _recipesService = recipesService;
    _auth = auth;
  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetRecipes()
  {
    try
    {
      List<Recipe> recipes = _recipesService.GetRecipes();
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetOneRecipe(int recipeId)
  {
    try
    {
      Recipe recipe = _recipesService.GetOneRecipe(recipeId);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}/ingredients")]
  public ActionResult<List<Ingredient>> GetRecipeIngredients(int recipeId)
  {
    try
    {
      List<Ingredient> ingredients = _recipesService.GetRecipeIngredients(recipeId);
      return Ok(ingredients);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> GenerateRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.GenerateRecipe(recipeData);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{recipeId}")]
  [Authorize]
  public ActionResult<Recipe> EditRecipe([FromBody] Recipe recipeData, int recipeId)
  {
    try
    {
      recipeData.Id = recipeId;
      Recipe recipe = _recipesService.EditRecipe(recipeData, recipeId);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{recipeId}")]
  [Authorize]
  public ActionResult<string> DeleteRecipe(int recipeId)
  {
    try
    {
      string message = _recipesService.DeleteRecipe(recipeId);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}

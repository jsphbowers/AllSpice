namespace AllSpice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;

  public FavoritesService(FavoritesRepository repo)
  {
    _repo = repo;
  }

  internal Favorite AddFavorite(Favorite favoriteData)
  {
    Favorite favorite = _repo.AddFavorite(favoriteData);
    return favorite;
  }

  internal List<MyFavoriteRecipes> GetMyFavorites(string userId)
  {
    List<MyFavoriteRecipes> recipes = _repo.GetMyFavorites(userId);
    return recipes;
  }

  internal Favorite GetOneFavorite(int id)
  {
    Favorite favorite = _repo.GetOneFavorite(id);
    if (favorite == null)
    {
      throw new Exception("No favorites exist by this ID");
    }
    return favorite;
  }

  internal string RemoveFavorite(int favoriteId, string userId)
  {
    Favorite favorite = GetOneFavorite(favoriteId);
    if (favorite.AccountId != userId)
    {
      throw new Exception("GET OUTTA HERE YA CRAZY!");
    }
    _repo.Remove(favoriteId);
    return "You'll never have to cook that recipe ever again!";
  }
}

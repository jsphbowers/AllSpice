namespace AllSpice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite AddFavorite(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO favorites (recipeId, accountId)
    VALUES (@recipeId, @accountId);
    SELECT LAST_INSERT_ID();
    ";

    int id = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.Id = id;
    favoriteData.CreatedAt = DateTime.Now;
    favoriteData.UpdatedAt = DateTime.Now;
    return favoriteData;
  }

  internal List<MyFavoriteRecipes> GetMyFavorites(string userId)
  {
    string sql = @"
    SELECT
    fav.*,
    rec.*,
    prof.*
    FROM favorites fav
    JOIN recipes rec ON fav.recipeId = rec.id
    JOIN accounts prof ON rec.creatorId = prof.id
    WHERE fav.accountId = @userId;
    ";

    List<MyFavoriteRecipes> recipes = _db.Query<Favorite, MyFavoriteRecipes, Profile, MyFavoriteRecipes>
    (sql, (fav, rec, prof) =>
    {
      rec.Creator = prof;
      rec.FavoriteId = fav.Id;
      return rec;
    }, new { userId }).ToList();

    return recipes;
  }

  internal Favorite GetOneFavorite(int id)
  {
    string sql = @"
    SELECT
    *
    FROM favorites WHERE id = @id;
    ";

    Favorite favorite = _db.Query<Favorite>(sql, new { id }).FirstOrDefault();
    return favorite;
  }

  internal void Remove(int favoriteId)
  {
    string sql = @"
    DELETE FROM favorites WHERE id = @favoriteId;
    ";

    _db.Execute(sql, new { favoriteId });
  }
}

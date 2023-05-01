import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {
  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log('[GOT RECIPES]', res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
    logger.log('[MAPPED RECIPES]', AppState.recipes)
  }
}

export const recipesService = new RecipesService;
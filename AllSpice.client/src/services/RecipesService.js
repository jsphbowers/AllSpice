import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {
  async getRecipes() {
    const res = await api.get('api/recipes')
    // logger.log('[GOT RECIPES]', res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
    logger.log('[MAPPED RECIPES]', AppState.recipes)
  }

  async fetchIngredients(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('[GOT INGREDIENTS]', res.data)
    AppState.ingredients = res.data.map(i => new Ingredient(i))
    logger.log('[MAPPED INGREDIENTS]', AppState.ingredients)
  }

  async addIngredient(ingredientData) {
    // logger.log(ingredientData, '[THIS IS INGREDIENT DATA]')
    const res = await api.post(`api/ingredients`, ingredientData)
    // logger.log(res.data, '[INGREDIENT ADDED]')
    AppState.ingredients.push(new Ingredient(res.data))

  }
}

export const recipesService = new RecipesService;
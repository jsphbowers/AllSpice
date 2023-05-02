<template>
  <div class="recipeCard bg-secondary m-4 selectable d-flex text-light elevation-3" @click="setActiveRecipe(recipe.id)"
    data-bs-toggle="modal" data-bs-target="#recipeModal">
    <img :src="recipe.img" alt="">
    <div class="categoryCard">
      <h5 class="textShadow">{{ recipe.category }}</h5>

      <i class="mdi text-danger px-3 mdi-heart"></i>
    </div>
    <div class="title-description">
      <h4 class="textShadow">{{ recipe.title }}</h4>
    </div>
  </div>

  <RecipeModal id="recipeModal" />
</template>


<script>
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import { logger } from "../utils/Logger.js";

export default {
  props: {
    recipe: { type: Recipe, required: true }
  },
  setup() {
    return {
      setActiveRecipe(recipeId) {
        AppState.activeRecipe = AppState.recipes.find(r => r.id == recipeId)
        logger.log(AppState.activeRecipe, '[WE SET THE ACTIVE RECIPE]')
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.recipeCard {
  height: 40vh;
  width: 40vh;
  border-radius: 10px;
}

img {
  height: 40vh;
  width: 40vh;
  border-radius: 10px;
  object-position: center;
  object-position: cover;
  position: relative
}

.categoryCard {
  display: flex;
  background: transparent;
  backdrop-filter: blur(4px);
  border-radius: 10px;
  position: absolute;
  top: 5%;
  left: 5%;
  justify-content: space-between;
}

.title-description {
  display: flex;
  background: transparent;
  backdrop-filter: blur(4px);
  border-radius: 10px;
  position: absolute;
  bottom: 5%;
  justify-content: space-between;
  margin-left: 1em;
  padding: 2%;
}

.textShadow {
  text-shadow: 1px 1px black;
}
</style>
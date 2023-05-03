<template>
  <div class="container-fluid" v-if="activeRecipe">
    <section class="row">
      <div class="col-4">
        <img :src="activeRecipe.img" :alt="activeRecipe.title">
      </div>
      <div class="col-8">
        <div class="d-flex justify-content-between m-2">
          <h4>{{ activeRecipe.title }}</h4>
          <div class="d-flex">
            <h6 class="category">{{ activeRecipe.category }}</h6>
            <button class="btn btn-info mx-2" title="edit"><i class="mdi mdi-pen"></i></button>
          </div>
        </div>

        <div class="d-flex p-2">
          <div class="instructionsCard bg-primary p-3 mx-2 text-warning">
            <h6>Instructions</h6>
            <p>{{ activeRecipe.instructions }}</p>
          </div>
          <div class="instructionsCard bg-primary p-3 mx-2 text-warning">
            <h6>
              Ingredients
            </h6>
            <p v-for="i in ingredient">{{ i.quantity }} : {{ i.name }}</p>
          </div>
        </div>
        <div v-if="activeRecipe.creatorId == account.id">
          <form @submit.prevent="addIngredient()">
            <div class="d-flex input-group mb-3">
              <span class="input-group-text" id="inputGroup-sizing-default">Ingredient Name</span>
              <input v-model="editable.name" type="text" class="form-control" aria-label="Sizing example input"
                aria-describedby="inputGroup-sizing-default">
              <span class="input-group-text" id="inputGroup-sizing-default">Quantity</span>
              <input v-model="editable.quantity" type="text" class="form-control" aria-label="Sizing example input"
                aria-describedby="inputGroup-sizing-default">
            </div>
            <button class="btn btn-primary">Add to Ingredients</button>
          </form>
        </div>

      </div>
    </section>
  </div>
</template>


<script>
import { computed, onMounted, ref } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      account: computed(() => AppState.account),
      ingredient: computed(() => AppState.ingredients),
      activeRecipe: computed(() => AppState.activeRecipe),
      async addIngredient() {
        try {
          let ingredientData = editable.value
          ingredientData.recipeId = AppState.activeRecipe.id
          await recipesService.addIngredient(ingredientData)
        } catch (error) {
          Pop.error(error)
          logger.error(error)
        }
        // logger.log(ingredientData, '[THIS IS THE INGREDIENT DATA]')
      }
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  object-fit: cover;
  object-position: center;
  height: 40vh;
  width: 100%;
  border-top-left-radius: 10px;
  border-bottom-left-radius: 10px;
}

.category {
  padding: 8px;
  border-radius: 30px;
  background-color: #0d3b5b5f
}

.instructionsCard {
  border-radius: 10px;
}
</style>
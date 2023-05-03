<template>
  <div class="container-fluid" v-if="activeRecipe">
    <section class="row">
      <div class="col-4">
        <img :src="activeRecipe.img" :alt="activeRecipe.title">
      </div>
      <div class="col-8">
        <div class="d-flex justify-content-between">
          <h4>{{ activeRecipe.title }}</h4>
          <h6 class="category bg-primary">{{ activeRecipe.category }}</h6>
        </div>
        <div class="d-flex justify-content-around p-3">
          <div class="instructionsCard bg-primary p-3">
            <h6>Instructions</h6>
            <p>{{ activeRecipe.instructions }}</p>
          </div>
          <div class="instructionsCard bg-primary p-3">
            <h6>
              Ingredients
            </h6>
            <p>Listed Ingredients</p>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<script>
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";

export default {
  setup() {
    return {
      activeRecipe: computed(() => AppState.activeRecipe),
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  object-fit: cover;
  object-position: center;
  height: 40vh;
  width: 30vh;
  border-top-left-radius: 10px;
  border-bottom-left-radius: 10px;
}

.category {
  padding: 8px;
  border-radius: 30px;
}

.instructionsCard {
  border-radius: 10px;
}
</style>
<template>
  <div class="container-fluid">

    <!-- SECTION Recipe Cards -->
    <section class="row">
      <div v-if="recipes" v-for="r in recipes">
        {{ r.title }}
      </div>
    </section>

  </div>
</template>

<script>
import { computed, onMounted } from "vue";
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";

export default {
  setup() {
    onMounted(() => {
      getRecipes()
    })
    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        Pop.error(error.message)
        logger.error(error)
      }
    }
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>

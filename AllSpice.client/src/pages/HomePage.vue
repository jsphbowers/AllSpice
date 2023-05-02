<template>
  <div class="container-fluid">
    <!-- SECTION Header and Nav Bar -->

    <section class="row">
      <div class="col-12">
        <section class="row justify-content-center">
          <div class="col-4 absolute ">
            <div class="filter-bar text-center p-2 d-flex justify-content-center justify-content-evenly">
              <button class="btn btn-warning text-primary" @click="changeFilterCategory('All')">All</button>
              <button class="btn btn-warning text-primary" @click="changeFilterCategory('myRecipes')">My Recipes</button>
              <button class="btn btn-warning text-primary" @click="changeFilterCategory('Favorites')">Favorites</button>
            </div>
          </div>
        </section>
      </div>
    </section>

    <!-- SECTION Recipe Cards -->
    <section class="row">
      <div class="col-md-6 col-lg-3 d-flex justify-content-center" v-if="recipes" v-for="r in recipes">
        <RecipeCard :recipe="r" />
      </div>
    </section>

  </div>
</template>

<script>
import { computed, onMounted, ref } from "vue";
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { Modal } from "bootstrap";

export default {
  setup() {
    const filterCategory = ref("");
    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error.message);
        logger.error(error);
      }
    }
    return {
      account: computed(() => AppState.account),
      recipes: computed(() => {
        if (!filterCategory.value) {
          return AppState.recipes;
        }
        else {
          return AppState.recipes.filter(r => r.category == filterCategory.value);
        }
      }),
      changeFilterCategory(category) {
        filterCategory = category;
      }
    };
  },
  components: {}
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

.filter-bar {
  background-color: #e4f2ffda;
  position: relative;
  bottom: 40%;
  border-radius: 10px;
}
</style>

<template></template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {
    return {
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped></style>
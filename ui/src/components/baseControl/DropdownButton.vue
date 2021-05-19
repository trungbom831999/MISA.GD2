<template>
  <v-menu
    offset-y
    allow-overflow
    left
    :top="top"
    min-width="fit-content"
  >
    <template v-slot:activator="{ on, attrs }">
      <div v-bind="attrs" v-on="on">
        <slot name="dropdown-button"></slot>
      </div>
    </template>
    <v-list class="v-list-menu mt-0" style="border: none">
      <slot name="dropdown-list"></slot>
    </v-list>
  </v-menu>
</template>

<script>
export default {
  props:{
    top:{
      type: Boolean,
      default:false
    }
  }
}
</script>

<style scoped>
.v-list-menu {
  padding: 2px 1px;
  margin-top: 2px;
  border-radius: 2px;
  border: 1px solid #babec5;
}

.v-menu__content {
    position: absolute;
    display: inline-block;
    max-width: 80%;
    overflow-y: auto;
    overflow-x: hidden;
    contain: content;
    will-change: transform;
    box-shadow: none;
    border-radius: 0;
}
</style>
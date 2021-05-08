<template>
    <div class="router-content">
          <router-view></router-view>
      </div>
</template>

<style scoped>
.router-content {
  padding-top: 48px;
  padding-left: 20px;
  background: #f4f5f6;
}

.content-area {
  padding-right: 30px;
  overflow: scroll;
  height: calc(100vh - 48px);
}
</style>